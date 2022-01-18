using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MorgantiCalculator { 
    public partial class Calculator : Form { 
        float? leftOperand = null;
        float? rightOperand = null;
        float? previousOperation = null;

        int? oper = null;
        readonly Dictionary<int?, char> operMap = new Dictionary<int?, char>() {{0,'+'}, {1,'-'}, {2,'×'}, {3, '÷' }, {4,'^'}, {5,'='}}; 

        StringBuilder currentEntry = new StringBuilder();

        public Calculator() {
            InitializeComponent();
        }

        private void Calculator_Load(object sender, EventArgs e) {
            resetOutput();
            KeyPress += Calculator_KeyPress;
        }

        private void btn_ce_Click(object sender, EventArgs e) {
            if (previousOperation != null) {
                resetAll();
            }
            else { 
                resetOutput();
            }
        }

        private void btn_c_Click(object sender, EventArgs e) {
            resetAll();
        }

        private void btn_del_Click(object sender, EventArgs e) {
            if (previousOperation != null) {
                resetAll();
            }
            if (currentEntry.Length > 0) {
                currentEntry.Remove(currentEntry.Length - 1, 1);
                updateOutput();
                if (currentEntry.Length == 0) {
                    resetOutput();
                }
            }
        }

        private void but_neg_Click(object sender, EventArgs e) {
            if (previousOperation != null) {
                float? holder = previousOperation;
                resetAll();
                if (holder != 0) {
                    currentEntry.Append(holder.ToString());
                }
            }
            if (currentEntry.Length != 0 && currentEntry[0] != 0) {
                if (currentEntry[0] != '-') {
                    currentEntry.Insert(0, '-');
                }
                else if (currentEntry[0] == '-') {
                    currentEntry.Remove(0, 1);
                }
                updateOutput();
            }

        }

        private void btn_dec_Click(object sender, EventArgs e) {
            if (previousOperation != null) {
                resetAll();
            }
            if (!currentEntry.ToString().Contains('.')) {
                if (currentEntry.Length == 0) {
                    currentEntry.Append('0');
                }
                currentEntry.Append('.');
                updateOutput();
            }
        }

        private void btn_equal_Click(object sender, EventArgs e) {
            // if the user presses equals immediately following a previous equals
            if (previousOperation != null) {
                if (oper != null) {
                    DoEquals();
                }
            }
            // if the user pressed equal when there's nothing
            else if (leftOperand == null && currentEntry.Length == 0) {
                previousOperation = 0;
                txt_prev.Text = "0 =";
            }
            // if the user pressed equals when there is only a number
            else if (leftOperand == null && currentEntry.Length != 0) {
                previousOperation = float.Parse(currentEntry.ToString());
                txt_prev.Text = previousOperation.ToString() + " =";
            }
            // if the user pressed equals when there is an operator and no right-operand
            else if (leftOperand != null && currentEntry.Length == 0) {
                rightOperand = leftOperand;
                DoEquals();
            }
            // if the user pressed equals where there is an operator and another input 
            else if (leftOperand != null && currentEntry.Length != 0) {
                rightOperand = float.Parse(currentEntry.ToString());
                DoEquals();
            }
        }

        private void DoEquals () {
            // checks for validity
            float? result = DoOperator();
            if (result == null) {
                if (rightOperand != 0 || oper != 3) {
                    txt_output.Text = "Invalid Input";
                }
            }
            else {
                previousOperation = result;
                txt_prev.Text = String.Format("{0} {1} {2} =", leftOperand.ToString(), operMap[oper], rightOperand.ToString());
                txt_output.Text = result.ToString();
                leftOperand = result;
            }
        }

        private void btn_inv_Click(object sender, EventArgs e) {

        }

        private void btn_sqrt_Click(object sender, EventArgs e) {

        }

        private void btn_square_Click(object sender, EventArgs e) {
            // Case where previousResult is still saved, will just run operation on that
            if (previousOperation != null) {
                rightOperand = null;
                oper = null;
                leftOperand = (float?)Math.Pow((double)previousOperation, 2);
                txt_prev.Text = string.Format("sqr({0})", previousOperation.ToString());
                txt_output.Text = leftOperand.ToString();
                previousOperation = null;
                currentEntry.Clear();
                //currentEntry.Append(leftOperand.ToString());
            }
            // Case where user has not entered entered anything. The input is just a 0

        }

        private void btn_power_Click(object sender, EventArgs e) {
            ExecuteOperator(4);
        }

        private void btn_div_Click(object sender, EventArgs e) {
            ExecuteOperator(3);
        }

        private void btn_mult_Click(object sender, EventArgs e) {
            ExecuteOperator(2);
        }

        private void btn_sub_Click(object sender, EventArgs e) {
            ExecuteOperator(1);
        }

        private void btn_add_Click(object sender, EventArgs e) {
            ExecuteOperator(0);
        }

        private void ExecuteOperator(int opCode) {
            if (previousOperation != null) {
                if (oper == null) {
                    leftOperand = previousOperation;
                }
                previousOperation = null;
                rightOperand = null;
                currentEntry.Clear();
            }

            if (currentEntry.Length > 0 && currentEntry[currentEntry.Length-1] == '.') {
                btn_del_Click(new object(), new EventArgs());
            }

            // Initial case where the user hasn't inputed anything yet
            // Should automatically fill with a 0
            if (currentEntry.Length == 0 && leftOperand == null) {
                oper = opCode;
                leftOperand = 0;
                resetOutput();

                txt_prev.Text = leftOperand.ToString() + " " + operMap[opCode];
            }
            // Case where the user has not entered anything new
            // Will update the operator
            else if (currentEntry.Length == 0 && leftOperand != null) {
                oper = opCode;

                txt_prev.Text = leftOperand.ToString() + " " + operMap[opCode];
            }
            // Case where the user has input some number and is the first operator pressed
            // Will store the operator and allow for new input
            else if (currentEntry.Length != 0 && leftOperand == null) {
                oper = opCode;
                leftOperand = float.Parse(currentEntry.ToString());
                currentEntry.Clear();

                txt_prev.Text = leftOperand.ToString() + " " + operMap[opCode];
            }
            // Case where the user hits an operator a second time
            // Will execute the previous operator and return result
            else if (currentEntry.Length != 0 && leftOperand != null) {
                rightOperand = float.Parse(currentEntry.ToString());

                float? retVal = DoOperator();

                leftOperand = retVal;
                rightOperand = null;
                oper = opCode;

                currentEntry.Clear();
                txt_output.Text = retVal.ToString();
                txt_prev.Text = leftOperand.ToString() + " " + operMap[opCode];
            }
        }

        float? DoOperator () {
            float? retVal = null;

            switch (oper) {
                case 0:
                    retVal = leftOperand + rightOperand;
                    break;
                case 1:
                    retVal = leftOperand - rightOperand;
                    break;
                case 2:
                    retVal = leftOperand * rightOperand;
                    break;
                case 3:
                    if (rightOperand == 0) {
                        txt_output.Text = "Cannot divide by 0";
                        txt_prev.Text = "";
                        leftOperand = null;
                        rightOperand = null;
                        oper = null;
                        currentEntry.Clear();
                    }
                    else {
                        retVal = leftOperand / rightOperand;
                    }
                    break;
                case 4:
                    retVal = (float?)Math.Pow((double)leftOperand, (double)rightOperand);
                    break;
            }
            return retVal;
        }

        #region Numbered Button Click Events
        private void btn_9_Click(object sender, EventArgs e) {
            addInput('9');
        }

        private void btn_8_Click(object sender, EventArgs e) {
            addInput('8');
        }

        private void btn_7_Click(object sender, EventArgs e) {
            addInput('7');
        }

        private void btn_6_Click(object sender, EventArgs e) {
            addInput('6');
        }

        private void btn_5_Click(object sender, EventArgs e) {
            addInput('5');
        }

        private void btn_4_Click(object sender, EventArgs e) {
            addInput('4');
        }

        private void btn_3_Click(object sender, EventArgs e) {
            addInput('3');
        }

        private void btn_2_Click(object sender, EventArgs e) {
            addInput('2');
        }

        private void btn_1_Click(object sender, EventArgs e) {
            addInput('1');
        }

        private void btn_0_Click(object sender, EventArgs e) {
            if (leftOperand != null && currentEntry.Length == 0) {
                addInput('0');
            }
            else if (currentEntry.Length > 0 && (currentEntry[0] != '0' || currentEntry.ToString().Contains('.'))) {
                addInput('0');
            }
        }
        #endregion

        void Calculator_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == '0')
                btn_0_Click(sender, e);
            else if ((int)e.KeyChar > 48 && (int)e.KeyChar < 58)
                addInput(e.KeyChar);
            else if (e.KeyChar == '+')
                btn_add_Click(sender, e);
            else if (e.KeyChar == '-')
                btn_sub_Click(sender, e);
            else if (e.KeyChar == '*')
                btn_mult_Click(sender, e);
            else if (e.KeyChar == '/')
                btn_div_Click(sender, e);
            else if (e.KeyChar == '^')
                btn_power_Click(sender, e);
            else if (e.KeyChar == '.')
                btn_dec_Click(sender, e);
            else if ((int)e.KeyChar == 8)
                btn_del_Click(sender, e);
            else if ((int)e.KeyChar == 27)
                btn_c_Click(sender, e);
        }

        private void addInput(char numb) {
            if (previousOperation != null) {
                resetAll();
            }
            if (currentEntry.Length < 16) {
                currentEntry.Append(numb);
            }
            updateOutput();
        }

        private void updateOutput() {
            txt_output.Text = currentEntry.ToString();
            if (currentEntry.Length == 0) {
                resetOutput();
            }
        }

        private void resetOutput() {
            txt_output.Text = "0";
            currentEntry.Clear();
        }

        private void resetAll () {
            previousOperation = null;
            leftOperand = null;
            rightOperand = null;
            oper = null;
            txt_prev.Text = "";
            txt_output.Text = "0";
            currentEntry.Clear();
        }
    }
}
