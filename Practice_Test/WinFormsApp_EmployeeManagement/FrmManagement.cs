using DataAccessLibrary.Repository;
using MyLibrabry.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp_EmployeeManagement
{
    public partial class FrmManagement : Form
    {
        public Dbaccount adminAccount { get; set; }
        public FrmLogin frmLogin { get; set; }
        public readonly IEmployeeRepository employeeRepository = new EmployeeRepository();
        public readonly IJobTitleRepository jobTitleRepository = new JobTitleRepository();
        public BindingSource source { get; set; }
        public FrmManagement()
        {
            InitializeComponent();
        }

        private void FrmManagement_Load(object sender, EventArgs e)
        {
            LoadEmployeeList();
        }

        public void LoadEmployeeList()
        {
            try
            {
                if (adminAccount != null)
                {
                    if (adminAccount.AccountRole.Value == 1)
                    {
                        source = new BindingSource();
                        List<Employee> employees = employeeRepository.GetEmployeeList();
                        if (employees.Count > 0)
                        {
                            foreach (var item in employees)
                            {
                                JobTitle job = jobTitleRepository.GetJobTitleByID(item.JobTitleId);
                                item.JobTitle = job;
                                
                            }
                            BtnDelete.Enabled = true;
                            BtnUpdate.Enabled = true;
                            source.DataSource = employees;
                            DgvEmployeeList.DataSource = source;
                            DgvEmployeeList.Columns[4].Visible = false;
                        } else
                        {
                            BtnUpdate.Enabled = false;
                            BtnDelete.Enabled = false;
                            DgvEmployeeList.DataSource = null;
                        }
                    } else
                    {
                        MessageBox.Show("You are not allowed to access this function!", "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        frmLogin.Show();
                    }
                } else
                {
                    MessageBox.Show("You are not allowed to access this function!", "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    frmLogin.Show();
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Employee List-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (adminAccount != null)
                {
                    if (adminAccount.AccountRole.Value == 1)
                    {
                        FrmEmployee frmEmployee = new FrmEmployee()
                        {
                            adminAccount = this.adminAccount,
                            frmLogin = this.frmLogin,
                            FrmManagement = this,
                            UpdateOrInsert = "Insert"
                        };
                        frmEmployee.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to access this function!", "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You are not allowed to access this function!", "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Employee List-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (adminAccount != null)
                {
                    if (adminAccount.AccountRole.Value == 1)
                    {
                        int index = DgvEmployeeList.CurrentRow.Index;
                        string empID = DgvEmployeeList.Rows[index].Cells[0].Value.ToString();
                        Employee employee = employeeRepository.GetEmployeeById(empID);
                        FrmEmployee frmEmployee = new FrmEmployee()
                        {
                            adminAccount = this.adminAccount,
                            frmLogin = this.frmLogin,
                            FrmManagement = this,
                            UpdateOrInsert = "Update",
                            employee = employee
                        };
                        frmEmployee.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to access this function!", "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You are not allowed to access this function!", "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Employee List-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (adminAccount != null)
                {
                    if (adminAccount.AccountRole.Value == 1)
                    {
                        int index = DgvEmployeeList.CurrentRow.Index;
                        DialogResult result = MessageBox.Show($"Are you sure that you want to delete the employee: {DgvEmployeeList.Rows[index].Cells[1].Value}-ID: {DgvEmployeeList.Rows[index].Cells[0].Value}",
                            "Delete-Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string empID = DgvEmployeeList.Rows[index].Cells[0].Value.ToString();
                            Employee employee = employeeRepository.GetEmployeeById(empID);
                            if (employee != null)
                            {
                                bool deleteresult = employeeRepository.DeleteEmployee(employee);
                                if (deleteresult)
                                {
                                    MessageBox.Show("Deleted Successfully", "Delete a employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadEmployeeList();
                                }
                            } else
                            {
                                MessageBox.Show("This Employee does not exist in the system", "Delete a employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        } else
                        {
                            LoadEmployeeList();
                        }
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to access this function!", "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You are not allowed to access this function!", "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Employee List-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (adminAccount != null)
                {
                    if (adminAccount.AccountRole.Value == 1)
                    {
                        string searchValue = TxtSearchValue.Text;
                        if (searchValue.Length == 0)
                        {
                            LoadEmployeeList();
                        } else
                        {
                            source = new BindingSource();
                            List<Employee> employees = employeeRepository.SerachEmployeeByDepartmentName(searchValue);
                            if (employees.Count > 0)
                            {
                                BtnDelete.Enabled = true;
                                BtnUpdate.Enabled = true;
                                source.DataSource = employees;
                                DgvEmployeeList.DataSource = source;
                                DgvEmployeeList.Columns[5].Visible = false;
                            } else
                            {
                                BtnDelete.Enabled = false;
                                BtnUpdate.Enabled = false;
                                DgvEmployeeList.DataSource = null;
                            }
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to access this function!", "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        frmLogin.Show();
                    }
                }
                else
                {
                    MessageBox.Show("You are not allowed to access this function!", "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    frmLogin.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Employee List-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvEmployeeList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                JobTitle job = (JobTitle)e.Value;
                e.Value = job.JobTitleName;
            }
        }
    }
}
