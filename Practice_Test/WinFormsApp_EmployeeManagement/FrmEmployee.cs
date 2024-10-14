using DataAccessLibrary.Repository;
using MyLibrabry.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp_EmployeeManagement
{
    public partial class FrmEmployee : Form
    {
        public Dbaccount adminAccount { get; set; }
        public FrmLogin frmLogin { get; set; }
        public string UpdateOrInsert { get; set; }
        public Employee employee { get; set; }
        public FrmManagement FrmManagement { get; set; }
        public readonly IEmployeeRepository employeeRepository = new EmployeeRepository();
        public readonly IJobTitleRepository jobTitleRepository = new JobTitleRepository();
    
        public FrmEmployee()
        {
            InitializeComponent();
        }

        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            LoadEmployee();
        }

        public void LoadEmployee()
        {
            try
            {
                if (adminAccount != null)
                {
                    if (adminAccount.AccountRole.Value == 1)
                    {
                        List<JobTitle> jobTitles = jobTitleRepository.GetJobTitles();
                        CbbJobTitle.DataSource = jobTitles;
                        CbbJobTitle.DisplayMember = "JobTitleName";
                        CbbJobTitle.ValueMember = "JobTitleId";
                        if (UpdateOrInsert.Equals("Insert"))
                        {
                            this.Text = "Insert a new employee";
                            BtnAction.Text = "Insert";
                        } else
                        {
                            this.Text = "Update a new employee";
                            BtnAction.Text = "Update";
                            txtEmployeeName.Text = employee.EmployeeName;
                            TxtDepartmentName.Text = employee.DepartmentName;
                            TxtEmployeeId.Text = employee.EmployeeId;
                            TxtYearOfBirth.Text = employee.YearOfBirth.Value.ToString();
                            CbbJobTitle.Text = jobTitleRepository.GetJobTitleByID(employee.JobTitleId).JobTitleName;
                        } 
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to access this function!", "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        FrmManagement.Close();
                        frmLogin.Show();
                    }
                }
                else
                {
                    MessageBox.Show("You are not allowed to access this function!", "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    FrmManagement.Close();
                    frmLogin.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Employee List-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Employee CheckValidateInput()
        {
            try
            {
                if (adminAccount != null)
                {
                    if (adminAccount.AccountRole.Value == 1)
                    {
                        string employeeID = TxtEmployeeId.Text;
                        string employeeName = txtEmployeeName.Text;
                        string yearOfBirth = TxtYearOfBirth.Text;
                        int year = 0;
                        string pattern = @"[0-9]{4,4}";
                        string namePattern = "[^\\p{L}\\s]";
                        Regex regex = new Regex(pattern);
                        Regex nameRegex = new Regex(namePattern);
                        string departmentName = TxtDepartmentName.Text;
                        string jobtitleID = CbbJobTitle.SelectedValue.ToString();
                        bool found = false;
                        string error = "";
                        if (employeeID.Length == 0)
                        {
                            found = true;
                            error += "Employee ID is required.\n";
                        } else
                        {
                            if (UpdateOrInsert.Equals("Update"))
                            {
                                if (employee.EmployeeId.Equals(employeeID) == false)
                                {
                                    Employee employee = employeeRepository.GetEmployeeById(employeeID);
                                    if (employee != null)
                                    {
                                        found = true;
                                        error += "Employee ID existed in the system.\n";
                                    }
                                }
                            } else
                            {
                                Employee employee = employeeRepository.GetEmployeeById(employeeID);
                                if (employee != null)
                                {
                                    found = true;
                                    error += "Employee ID existed in the system.\n";
                                }
                            }
                        }

                        if (employeeName.Length < 10)
                        {
                            found = true;
                            error += "Employee name is required greater than 10 characters.\n";
                        } else
                        {
                            if (nameRegex.IsMatch(employeeName) == false)
                            {
                                string[] name = employeeName.Split(" ");
                                foreach (var item in name)
                                {
                                    if (item.ElementAt(0).ToString().ToUpper().Equals(item.ElementAt(0).ToString()) == false)
                                    {
                                        found = true;
                                        error += "Each word of the Employee Name must begin with the capital letter.\n";
                                        break;
                                    }
                                }
                            } else
                            {
                                found = true;
                                error += "Employee name does not contains any special characters.\n";
                            }
                        }

                        if (yearOfBirth.Length == 0)
                        {
                            found = true;
                            error += "Year of Birth is required.\n";
                        } else
                        {
                            if (regex.IsMatch(yearOfBirth))
                            {
                                year = int.Parse(yearOfBirth);
                                if (year < 1960 || year > 2002)
                                {
                                    found = true;
                                    error += "Year of birth is required 1960-2002";
                                }
                            } else
                            {
                                found = true;
                                error += "Year of Birth is invalid.\n";
                            }
                        }

                        if (departmentName.Length == 0)
                        {
                            found = true;
                            error += "Department name is required.\n";
                        } else if (nameRegex.IsMatch(departmentName))
                        {
                            found = true;
                            error += "Department name does not contains any special characters.\n";
                        }
                        if (found)
                        {
                            string title = "";
                            if (UpdateOrInsert.Equals("Update"))
                            {
                                title = "Update a employee";
                            } else
                            {
                                title = "Insert a employee";
                            }
                            MessageBox.Show(error, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        } else
                        {
                            Employee newEmployee = new Employee()
                            {
                                DepartmentName = departmentName,
                                EmployeeId = employeeID,
                                EmployeeName = employeeName,
                                JobTitleId = jobtitleID,
                                YearOfBirth = year
                            };
                            return newEmployee;
                        }

                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to access this function!", "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        FrmManagement.Close();
                        frmLogin.Show();
                    }
                }
                else
                {
                    MessageBox.Show("You are not allowed to access this function!", "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    FrmManagement.Close();
                    frmLogin.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Employee List-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private void BtnAction_Click(object sender, EventArgs e)
        {
            try
            {
                if (adminAccount != null)
                {
                    if (adminAccount.AccountRole.Value == 1)
                    {
                        Employee employee = CheckValidateInput();
                        if (employee != null)
                        {
                            if (UpdateOrInsert.Equals("Update"))
                            {
                                bool status = employeeRepository.UpdateEmployee(employee);
                                if (status)
                                {
                                    MessageBox.Show("Updated Successfully", "Update a employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                    FrmManagement.LoadEmployeeList();
                                }
                            } else
                            {
                                bool status = employeeRepository.InsertEmployee(employee);
                                if (status)
                                {
                                    MessageBox.Show("Inserted Successfully", "Insert a employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                    FrmManagement.LoadEmployeeList();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to access this function!", "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        FrmManagement.Close();
                        frmLogin.Show();
                    }
                }
                else
                {
                    MessageBox.Show("You are not allowed to access this function!", "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    FrmManagement.Close();
                    frmLogin.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Employee List-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (adminAccount != null)
                {
                    if (adminAccount.AccountRole.Value == 1)
                    {
                        this.Close();
                        FrmManagement.LoadEmployeeList();
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to access this function!", "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        FrmManagement.Close();
                        frmLogin.Show();
                    }
                }
                else
                {
                    MessageBox.Show("You are not allowed to access this function!", "Login-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    FrmManagement.Close();
                    frmLogin.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Employee List-Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
