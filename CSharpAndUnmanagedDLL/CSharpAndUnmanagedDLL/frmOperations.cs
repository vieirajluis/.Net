using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpAndUnmanagedDLL
{
    public partial class frmOperations : Form
    {
        public frmOperations()
        {
            InitializeComponent();
        }
        [DllImport("UnmanagedDll.dll",  CallingConvention = CallingConvention.Cdecl)]
        public static extern int add(int a, int b);

        private void btnAdd_Click(object sender, EventArgs e)
        {

            int x = Convert.ToInt32(textBox1.Text);
            int y = Convert.ToInt32(textBox2.Text);
            int z = add(x, y);
            MessageBox.Show("Required Answer is " + Convert.ToString(z), "Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [DllImport("UnmanagedDll.dll",  CallingConvention = CallingConvention.Cdecl)]
        public static extern int subtract(int a, int b);
        private void btnSub_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            int y = Convert.ToInt32(textBox2.Text);
            int z = subtract(x, y);
            MessageBox.Show("Required Answer is " + Convert.ToString(z), "Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [DllImport("UnmanagedDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int mult(int a, int b);
        private void btnMult_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            int y = Convert.ToInt32(textBox2.Text);
            int z = mult(x, y);
            MessageBox.Show("Required Answer is " + Convert.ToString(z), "Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [DllImport("UnmanagedDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int div(int a, int b);
        private void btnDiv_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            int y = Convert.ToInt32(textBox2.Text);
            int z = div(x, y);
            MessageBox.Show("Required Answer is " + Convert.ToString(z), "Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
