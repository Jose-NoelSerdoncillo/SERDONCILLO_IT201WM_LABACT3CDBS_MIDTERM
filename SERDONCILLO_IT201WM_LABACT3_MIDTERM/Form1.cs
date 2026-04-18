using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERDONCILLO_IT201WM_LABACT3_MIDTERM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string CheckIfEmpty(string text)
        {
            if (text == "") return "Empty";
            return "Ok";
        }

        string CheckIfNumber(string text)
        {
            double result;
            if (double.TryParse(text, out result)) return "Ok";
            return "Not a Number";
        }

        string CheckAffordability(double budget, double cost)
        {
            if (cost > budget) return "Not Affordable"; 
            if (cost >= budget * 0.8) return "Critical"; 
            return "Affordable"; 
        }

        double ComputePriority(int importance, string urgency)
        {
            double weight = 1.0;
            if (urgency == "High") weight = 2.0; 
            else if (urgency == "Medium") weight = 1.0;
            else weight = 0.5;

            return importance * weight; 
        }
        string EvaluateRisk(string riskLevel)
        {
            return riskLevel; 
        }

        string GenerateDecision(string afford, double score, string risk)
        {
            if (afford == "Not Affordable" || risk == "High Risk") return "Not Recommended";
            if (score >= 10 && afford == "Affordable") return "Proceed Immediately"; 
            if (score < 5) return "Delay Decision"; 
            return "Proceed with Caution"; 
        }

        string GenerateExplanation(string decision)
        {
            if (decision == "Proceed Immediately") return "Everything looks good and within budget."; 
            if (decision == "Not Recommended") return "Too expensive or too much risk involved.";
            return "Take your time and review your options.";
        }

        void DisplayResult(string aff, double score, string risk, string dec, string expl)
        {
            label7.Text = "AFFORDABILITY: " + aff + "\n" + "PRIORITY SCORE: " + score + "\n" + "RISK LEVEL: " + risk + "\n" + "FINAL DECISION: " + dec + "\n\n" + "NOTE: " + expl; 
        }

        void ResetForm()
        {
            Budget.Text = ""; 
            Cost.Text = "";
            urgencylevel.Text = "";
            Risk.Text = "";
            Importance.Value = 1;   
            label7.Text = "Results cleared.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Basic Validation using our functions 
            if (CheckIfEmpty(Budget.Text) == "Yes" || CheckIfNumber(Budget.Text) == "No")
            {
                MessageBox.Show("Please check your Budget input!");
                return;
            }

            // Convert data from inputs 
            double budgetValue = double.Parse(Budget.Text);
            double costValue = double.Parse(Cost.Text);
            int importanceValue = (int)Importance.Value;
            string urgencyValue = urgencylevel.Text;
            string riskValue = Risk.Text;

            // Call logic functions 
            string affResult = CheckAffordability(budgetValue, costValue);
            double prioScore = ComputePriority(importanceValue, urgencyValue);
            string riskResult = EvaluateRisk(riskValue);
            string finalDec = GenerateDecision(affResult, prioScore, riskResult);
            string finalExpl = GenerateExplanation(finalDec);

            // Output everything
            DisplayResult(affResult, prioScore, riskResult, finalDec, finalExpl);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
