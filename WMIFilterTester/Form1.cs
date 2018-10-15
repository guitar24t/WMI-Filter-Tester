using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;

namespace WMIFilterTester
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public static TimeSpan timeSpan;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                textBox_DomainName.Text = (string)new DirectoryEntry("LDAP://RootDSE").Properties["DefaultNamingContext"][0];
                if (textBox_DomainName.Text != "")
                {
                    textBox_DomainName.ReadOnly = true;
                    button_GetDomain.PerformClick();
                    validateAllQueries();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void button_GetDomain_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_DomainName.Text == "")
                {
                    MessageBox.Show("You Must Enter a Domain Name!", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    listView_WMIFilters.Items.Clear();
                    listView_WMIFilters.Refresh();
                    using (DirectoryEntry searchRoot1 = new DirectoryEntry("LDAP://CN=Policies,CN=System," + textBox_DomainName.Text))
                    {
                        SearchResultCollection all1 = new DirectorySearcher(searchRoot1)
                        {
                            Filter = "(ObjectClass=groupPolicyContainer)",
                            PropertiesToLoad = {"gPCWQLFilter", "displayName"},
                            SearchScope = SearchScope.Subtree
                        }.FindAll();
                        if (all1.Count == 0)
                        {
                            MessageBox.Show("No GPOs found in this Domain");
                        }
                        else
                        {
                            using (DirectoryEntry searchRoot2 = new DirectoryEntry("LDAP://CN=SOM,CN=WMIPolicy,CN=System," + textBox_DomainName.Text))
                            {
                                SearchResultCollection all2 = new DirectorySearcher(searchRoot2)
                                {
                                    Filter = "(objectCategory=msWMI-Som)",
                                    SearchScope = SearchScope.Subtree
                                }.FindAll();
                                if (all2.Count == 0)
                                {
                                    MessageBox.Show("No WMI Filters found in this domain");
                                }
                                else
                                {
                                    int index1 = 0;
                                    foreach (SearchResult searchResult1 in all2)
                                    {
                                        string text = searchResult1.Properties["msWMI-Name"][0].ToString();
                                        string str1 = searchResult1.Properties["msWMI-Parm1"].Count != 0 ? searchResult1.Properties["msWMI-Parm1"][0].ToString() : "";
                                        string[] strArray1 = searchResult1.Properties["msWMI-Parm2"][0].ToString().Split(';');
                                        List<string> list = new List<string>();
                                        int num4 = strArray1.Length / 7;
                                        StringBuilder stringBuilder = new StringBuilder();
                                        for (int index2 = 0; index2 < num4; ++index2)
                                        {
                                            if (index2 == 0)
                                            {
                                                stringBuilder.Append(strArray1[5] + ";" + strArray1[6]);
                                            }
                                            else
                                            {
                                                stringBuilder.Append(";");
                                                stringBuilder.Append(strArray1[5 + 6 * index2] + ";" + strArray1[6 + 6 * index2]);
                                            }
                                        }
                                        string str2 = "";
                                        foreach (SearchResult searchResult2 in all1)
                                        {
                                            if (searchResult2.Properties["gPCWQLFilter"].Count > 0)
                                            {
                                                string[] strArray2 = searchResult2.Properties["gPCWQLFilter"][0].ToString().Split(';');
                                                if (strArray2.Length == 3 && strArray2[1] == searchResult1.Properties["cn"][0].ToString())
                                                    str2 = searchResult2.Properties["displayName"][0].ToString() + "," + str2;
                                            }
                                        }
                                        string str3 = str2.TrimEnd(';');
                                        string[] items = new string[3]
                                        {
                                          str1,
                                          ((object) stringBuilder).ToString(),
                                          str3
                                        };
                                        listView_WMIFilters.Items.Add(text);
                                        listView_WMIFilters.Items[index1].SubItems.AddRange(items);
                                        ++index1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error");
            }
        }

        private void validateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sQuery = listView_WMIFilters.SelectedItems[0].SubItems[2].Text;

            bool retVal = runValidation(sQuery);
            MessageBox.Show("WMI Filter evaluates to " + retVal.ToString().ToUpper() + " on the local computer \n and completed in: " + timeSpan.Hours + ":" + timeSpan.Minutes + ":" + timeSpan.Seconds + ":" + timeSpan.Milliseconds + " (hh:mm:ss:ms)", "WMI Validation Results");

        }

        public static bool runValidation(String sQuery)
        {
            try
            {
                ConnectionOptions options = new ConnectionOptions();
                string[] strArray = (sQuery).Split(new char[1]
                {
                  ';'
                });
                ManagementScope scope = new ManagementScope("\\\\" + "localhost" + "\\" + ((object)strArray[0]).ToString(), options);
                int num1 = 0;
                int num2 = strArray.Length / 2;
                timeSpan = new TimeSpan();
                for (int index = 0; index < num2; ++index)
                {
                    DateTime now1;
                    if (index == 0)
                    {
                        ObjectQuery query = new ObjectQuery(((object)strArray[1]).ToString());
                        ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(scope, query);
                        DateTime now2 = DateTime.Now;
                        ManagementObjectCollection objectCollection = managementObjectSearcher.Get();
                        now1 = DateTime.Now;
                        timeSpan = now1.Subtract(now2);
                        if (objectCollection.Count == 0)
                            ++num1;
                    }
                    else
                    {
                        ObjectQuery query = new ObjectQuery(((object)strArray[1 + 2 * index]).ToString());
                        ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(scope, query);
                        DateTime now2 = DateTime.Now;
                        ManagementObjectCollection objectCollection = managementObjectSearcher.Get();
                        now1 = DateTime.Now;
                        timeSpan = now1.Subtract(now2);
                        if (objectCollection.Count == 0)
                            ++num1;
                    }
                }
                if (num1 == 0)
                {
                    //MessageBox.Show("WMI Filter evaluates to TRUE on the local computer \n and completed in: " + timeSpan.Hours + ":" + timeSpan.Minutes + ":" + timeSpan.Seconds + ":" + timeSpan.Milliseconds + " (hh:mm:ss:ms)", "WMI Validation Results");
                    return true;
                }
                else
                {
                    //MessageBox.Show("WMI Filter evaluates to FALSE on the local computer \n and completed in: " + timeSpan.Hours + ":" + timeSpan.Minutes + ":" + timeSpan.Seconds + ":" + timeSpan.Milliseconds + " (hh:mm:ss:ms)", "WMI Validation Results");
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
        }

        private void cmdCustomQuery_Click(object sender, EventArgs e)
        {
            Form customQuery = null;
            if (listView_WMIFilters.SelectedItems.Count > 0)
            {
                if ((listView_WMIFilters.SelectedItems[0].SubItems[2].Text.Split(';')).Length > 1)
                    customQuery = new frmQueryEntry(listView_WMIFilters.SelectedItems[0].SubItems[2].Text.Split(';')[1]);
            }
            else
            {
                customQuery = new frmQueryEntry();
            }
            customQuery.ShowDialog();
        }

        private void listView_WMIFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_WMIFilters.SelectedItems.Count > 0)
            {
                cmdCustomQuery.Text = "Edit Query";
                cmdValidate.Enabled = true;
            }
            else
            {
                cmdCustomQuery.Text = "Validate Custom Query";
                cmdValidate.Enabled = false;
            }
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            validateToolStripMenuItem.PerformClick();
        }

        private void validateAllQueries()
        {
            int idx = 0;
            foreach (ListViewItem i in listView_WMIFilters.Items)
            {
                i.SubItems.Add(runValidation(i.SubItems[2].Text).ToString());
                idx++;
                if (idx >= 20)
                    break;
            }
        }
    }
}
