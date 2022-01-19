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
        int calculatorState = 0;
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
            if (calculatorState == -1) {
                resetAll();
            }
            if (calculatorState == 1 || calculatorState == 3) {
                resetOutput();
            }
            else if (calculatorState == 4 || calculatorState == 5) { 
                resetAll();
            }
            else if (calculatorState == 6) {
                resetOutput();
                updateTxtPrevious(String.Format("{0} {1}", leftOperand, operMap[oper]));
            }
        }

        private void btn_c_Click(object sender, EventArgs e) {
            resetAll();
        }

        private void btn_del_Click(object sender, EventArgs e) {
            if (calculatorState == -1) {
                resetAll();
            }
            if (calculatorState == 1) { 
                if (currentEntry.Length <= 1) {
                    resetAll();
                }
                else {
                    currentEntry.Remove(currentEntry.Length -1, 1);
                    updateOutput();
                }
            }
            else if (calculatorState == 3) {
                if (currentEntry.Length <= 1) {
                    resetOutput();
                }
                else {
                    currentEntry.Remove(currentEntry.Length -1, 1);
                    updateOutput();
                }
            }
            else if (calculatorState == 4) {
                // clear the top bar, but keep the result in the bottom bar and value

            }
            if (currentEntry.Length == 1 && currentEntry[0] == '-') {
                currentEntry.Clear();
                updateOutput();
            }
        }

        private void but_neg_Click(object sender, EventArgs e) {
            if (calculatorState == 1 || calculatorState == 3) {
                if (currentEntry.Length > 0 && currentEntry.ToString() != "0") {
                    if (currentEntry[0] == '-') 
                        currentEntry.Remove (0, 1);
                    else 
                        currentEntry.Insert(0, '-');
                    updateOutput();
                }
            }
            else if (calculatorState == 2) {
                currentEntry.Clear();
                 

                calculatorState = 6;
                

                // take leftOperator and make it negative
            }
            else if (calculatorState == 4) {
                // restore previous state and make it negative
            }
        }

        private void btn_dec_Click(object sender, EventArgs e) {
            if (calculatorState < 4) {
                if (currentEntry.Length == 0) {
                    addInput('0');
                    addInput('.');
                }
                else if (!currentEntry.ToString().Contains('.')) {
                    addInput('.');
                }
            }
            if (calculatorState == 4) {
                resetAll();
                btn_dec_Click(sender, e);
            }
        }

        private void btn_equal_Click(object sender, EventArgs e) {

            if (calculatorState == 0) {
                previousOperation = 0;
                updateTxtPrevious("0 =");
            }
            else if (calculatorState == 1) {
                float currentVal = float.Parse(currentEntry.ToString());
                previousOperation = currentVal;
                updateTxtPrevious(previousOperation.ToString() + " =");
            }
            else if (calculatorState == 2) {
                rightOperand = leftOperand;
                DoEquals();
            }
            else if (calculatorState == 3) {
                rightOperand = float.Parse(currentEntry.ToString());
                DoEquals();
            }
            else if (calculatorState == 4) {
                if (oper != null) {
                    DoEquals();
                }
            }
            else if (calculatorState == 5) {
                leftOperand = float.Parse(txt_output.Text);
                previousOperation = leftOperand;
                updateTxtPrevious(txt_prev.Text + " =");
            }
            else if (calculatorState == 6) {

            }
             
            if (calculatorState != -1) {
                calculatorState = 4;
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
                updateTxtPrevious (String.Format("{0} {1} {2} =", leftOperand.ToString(), operMap[oper], rightOperand.ToString()));
                txt_output.Text = result.ToString();
                leftOperand = result;
            }
        }

        private void btn_inv_Click(object sender, EventArgs e) {
            if (calculatorState == 0) {
                updateTxtPrevious("1/(0)");
                txt_output.Text = "Cannot divide by zero"; 
                calculatorState = -1;
            }
            else if (calculatorState == 1) {
                updateTxtPrevious(String.Format("1/({0})", currentEntry));
                txt_output.Text = Math.Pow(double.Parse(currentEntry.ToString()), -1).ToString();
                calculatorState = 5;
            }

        }

        private void btn_sqrt_Click(object sender, EventArgs e) {
            if (calculatorState == 0) {
                updateTxtPrevious("sqrt(0)");
                calculatorState = 5;
            }
            else if (calculatorState == 1) {
                updateTxtPrevious(String.Format("sqr({0})", currentEntry));
                txt_output.Text = Math.Sqrt(double.Parse(currentEntry.ToString())).ToString();
                calculatorState = 5;
            }
        }

        private void btn_square_Click(object sender, EventArgs e) {
            if (calculatorState == 0) {
                updateTxtPrevious("sqr(0)");
                calculatorState = 5;
            }
            else if (calculatorState == 1) {
                updateTxtPrevious(String.Format("sqr({0})", currentEntry));
                txt_output.Text = Math.Pow(double.Parse(currentEntry.ToString()), 2).ToString();
                calculatorState = 5;
            }
            else if (calculatorState == 2) {
                updateTxtPrevious(String.Format("{0} {1} sqr({2})", leftOperand, operMap[oper], txt_output.Text));
                txt_output.Text = Math.Pow((double)leftOperand, 2).ToString();
                calculatorState = 6;
            }
            else if (calculatorState == 3) {
                updateTxtPrevious(String.Format("{0} {1} sqr({2})", leftOperand, operMap[oper], txt_output.Text));
                txt_output.Text = Math.Pow(double.Parse(currentEntry.ToString()), 2).ToString();
                calculatorState = 6;
            }
            else if (calculatorState == 4) {
                updateTxtPrevious(String.Format("sqr({0})", previousOperation));
                txt_output.Text = Math.Pow((double)previousOperation, 2).ToString();
                leftOperand = null;
                previousOperation = null;
                rightOperand = null;
                oper = null;
                currentEntry.Clear();
                calculatorState = 5;
            }
            else if (calculatorState == 5) {
                updateTxtPrevious(String.Format("{0} {1} sqr({2})", leftOperand, operMap[oper], txt_output.Text));
                txt_output.Text = Math.Pow(double.Parse(currentEntry.ToString()), 2).ToString();
                calculatorState = 6;

            }
            else if (calculatorState == 6) {

            }

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
            if (currentEntry.Length > 0 && currentEntry[currentEntry.Length-1] == '.') {
                btn_del_Click(new object(), new EventArgs());
            }

            if (calculatorState == 0) {
                oper = opCode;
                leftOperand = 0;
                calculatorState = 2;
            }
            else if (calculatorState == 1) {
                oper = opCode;
                leftOperand = float.Parse(currentEntry.ToString());
                currentEntry.Clear();
                calculatorState = 2;
            }
            else if (calculatorState == 2) {
                oper = opCode;
            }
            else if (calculatorState == 3) {
                rightOperand = float.Parse(currentEntry.ToString());

                float? retVal = DoOperator();

                leftOperand = retVal;
                rightOperand = null;
                oper = opCode;

                currentEntry.Clear();
                txt_output.Text = retVal.ToString();
                calculatorState = 2;
            }
            else if (calculatorState == 4) {
                if (oper == null) {
                    leftOperand = previousOperation;
                }
                previousOperation = null;
                rightOperand = null;
                currentEntry.Clear();
                calculatorState = 2;
            }

            updateTxtPrevious(leftOperand.ToString() + " " + operMap[opCode]);
            oper = opCode;
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
            if (calculatorState == 4) {
                currentEntry.Clear();
            }
            if (currentEntry.Length < 16) {
                currentEntry.Append(numb);
                
                if (calculatorState == 0) 
                    calculatorState = 1;
                if (calculatorState == 2)
                    calculatorState = 3;

                updateOutput();
            }
        }

        private void updateOutput() {
            txt_output.Text = currentEntry.ToString();
            if (currentEntry.Length == 0) {
                resetOutput();
            }
        }

        private void updateTxtPrevious (string txt) {
            txt_prev.Text = txt;
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
            calculatorState = 0;
            currentEntry.Clear();
        }
    }
}
