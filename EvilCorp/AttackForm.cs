using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EvilCorp
{
    public partial class AttackForm : Form
    {
        public AttackForm()
        {
            InitializeComponent();
        }

        private void btnBruteForce_Click(object sender, EventArgs e)
        {
            BruteForceForm bruteForm = new BruteForceForm();
            bruteForm.ShowDialog();
        }

        private void btnDictionary_Click(object sender, EventArgs e)
        {
            DictionaryAttackForm dictForm = new DictionaryAttackForm();
            dictForm.ShowDialog();
        }
    }
}