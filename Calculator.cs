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
        // declare variables
        float? leftOperand = null;
        float? rightOperand = null;
        float? previousOperation = null;
        int? oper = null;
        readonly Dictionary<int?, char> operMap = new Dictionary<int?, char>() {{0,'+'}, {1,'-'}, {2,'×'}, {3, '÷' }, {4,'^'}, {5,'='}}; 
        StringBuilder currentEntry = new StringBuilder();

        // states: -1-error state, 0-nothing, 1-entering input first time
        //         2-pressed a normal operator, 3-entering input second time, 4-pressed equals
        //         5-special operation like 1\x, sqrt, etc. in the left argument
        //         6-special operation in the right argument
        int calculatorState = 0;


        // used to create the calculator
        public Calculator() {
            InitializeComponent();
        }

        // used when the calualtor loads
        private void Calculator_Load(object sender, EventArgs e) {
            resetOutput();
            KeyPress += Calculator_KeyPress;
        }

        #region Button Presses
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
            // will look to see if the user is trying to enter more than one 0 in the front
            if (leftOperand != null && currentEntry.Length == 0) {
                addInput('0');
            }
            else if (currentEntry.Length > 0 && (currentEntry[0] != '0' || currentEntry.ToString().Contains('.'))) {
                addInput('0');
            }
        }

        private void btn_ce_Click(object sender, EventArgs e) {
            // runs the ce operator depending on the current state of the calculator
            switch (calculatorState) {
                case -1:
                    resetAll();
                    break;
                case 1:
                    resetOutput();
                    break;
                case 3:
                    resetOutput();
                    break;
                case 4:
                    resetAll();
                    break;
                case 5:
                    resetAll();
                    break;
                case 6:
                    resetOutput();
                    updateTxtPrevious(String.Format("{0} {1}", leftOperand, operMap[oper]));
                    break;
            }
        }

        private void btn_c_Click(object sender, EventArgs e) {
            // The clear button will always just reset all
            resetAll();
        }

        private void btn_del_Click(object sender, EventArgs e) {
            // switch resulting action depending on current state
            switch (calculatorState) {
                case -1:
                    // resets everything
                    resetAll();
                    break;
                case 1:
                    // will either reset if the user cleared everything or delete the last character
                    if (currentEntry.Length <= 1) {
                        resetAll();
                    }
                    else {
                        currentEntry.Remove(currentEntry.Length -1, 1);
                        updateOutput();
                    }
                    break;
                case 3:
                    // will either reset to state 2 or delete the last character
                    if (currentEntry.Length <= 1) {
                        resetOutput();
                        calculatorState = 2;
                    }
                    else {
                        currentEntry.Remove(currentEntry.Length -1, 1);
                        updateOutput();
                    }
                    break;
                case 4:
                    // resets all
                    resetAll();
                    break;
            }

            // removes the negative sign if it's the only character or if the string is -0
            if (currentEntry.Length == 1 && currentEntry[0] == '-' || currentEntry.ToString() == "-0") {
                currentEntry.Clear();
                updateOutput();
            }
        }

        private void but_neg_Click(object sender, EventArgs e) {
            // will add/remove a negative sign in the string
            if (calculatorState == 1 || calculatorState == 3) {
                if (currentEntry.Length > 0 && currentEntry.ToString() != "0") {
                    if (currentEntry[0] == '-') 
                        currentEntry.Remove (0, 1);
                    else 
                        currentEntry.Insert(0, '-');
                    updateOutput();
                }
            }
            // will negate the entered left argument and put that into the next field
            // will result in the calculator being put in state 6
            else if (calculatorState == 2) {
                updateTxtPrevious(String.Format("{0} {1} negate({2})", leftOperand, operMap[oper], leftOperand));
                currentEntry.Clear();
                txt_output.Text = (-1 * leftOperand).ToString();
                calculatorState = 6;
            }
            // will negate the previous found answer
            // will put into state 5
            else if (calculatorState == 4) {
                updateTxtPrevious(String.Format("negate({0})", previousOperation));
                currentEntry.Clear();
                txt_output.Text = (-1 * previousOperation).ToString();
                calculatorState = 5;
            }
        }

        private void btn_decimal_Click(object sender, EventArgs e) {
            // when the decimal is pressed, either add 0. or just .
            if (calculatorState < 4) {
                if (currentEntry.Length == 0) {
                    addInput('0');
                    addInput('.');
                }
                else if (!currentEntry.ToString().Contains('.')) {
                    addInput('.');
                }
            }
            // when pressed, reset the entire thing and then put 0.
            if (calculatorState == 4) {
                resetAll();
                btn_decimal_Click(sender, e);
            }
        }

        private void btn_equal_Click(object sender, EventArgs e) {
            // switch depending on calculator state
            switch (calculatorState) {
                case 0:
                    // displays as 0 = 0 since nothing has been done
                    previousOperation = 0;
                    updateTxtPrevious("0 =");
                    AddHistory("0 = 0");
                    break;
                case 1:
                    // displays at x = x since only a number has been entered
                    float currentVal = float.Parse(currentEntry.ToString());
                    previousOperation = currentVal;
                    updateTxtPrevious(previousOperation.ToString() + " =");
                    AddHistory(String.Format("{0} = {0}", previousOperation));
                    break;
                case 2:
                    // Run the DoEquals with the left and right arguments the same
                    rightOperand = leftOperand;
                    DoEquals();
                    break;
                case 3:
                    // Run the DoEquals with all entered arguments
                    rightOperand = float.Parse(currentEntry.ToString());
                    DoEquals();
                    break;
                case 4:
                    // if the user has previously pressed equals from state 3, then reexecute the same equals
                    if (oper != null) 
                        DoEquals();
                    break;
                case 5:
                    // display the result of the special operation done to put the calculator into state 5
                    leftOperand = float.Parse(txt_output.Text);
                    previousOperation = leftOperand;
                    updateTxtPrevious(txt_prev.Text + " =");
                    AddHistory(txt_prev.Text + " " + previousOperation);
                    break;
                case 6:
                    // display the result of the operation with the output from the special operation done
                    rightOperand = float.Parse(txt_output.Text);
                    DoEquals();
                    break;
            }

            // if not in an error state then set the state to 4
            if (calculatorState != -1) {
                calculatorState = 4;
            }
        }

        private void btn_inv_Click(object sender, EventArgs e) {
            CalcSpecial("1/", -1);
        }

        private void btn_sqrt_Click(object sender, EventArgs e) {
            if (txt_output.Text[0] != '-')
                CalcSpecial("sqrt", (float)0.5);
            else
                SetErrorState("Invalid Input");
                
        }

        private void btn_square_Click(object sender, EventArgs e) {
            CalcSpecial("sqr", 2);
        }

        private void btn_power_Click(object sender, EventArgs e) {
            CalcOperator(4);
        }

        private void btn_div_Click(object sender, EventArgs e) {
            CalcOperator(3);
        }

        private void btn_mult_Click(object sender, EventArgs e) {
            CalcOperator(2);
        }

        private void btn_sub_Click(object sender, EventArgs e) {
            CalcOperator(1);
        }

        private void btn_add_Click(object sender, EventArgs e) {
            CalcOperator(0);
        }
        
        private void btn_history_Click(object sender, EventArgs e) {
            txt_history.Visible = !txt_history.Visible;
        }
        #endregion

        // Will attempt to run the calculation and will either put into an error state or success state
        private void DoEquals () {
            float? result = DoOperator();
            if (result == null) {
                SetErrorState("Invalid Input");
            }
            else {
                previousOperation = result;
                updateTxtPrevious (String.Format("{0} {1} {2} =", leftOperand, operMap[oper], rightOperand));
                AddHistory(txt_prev.Text + " " + result);
                txt_output.Text = result.ToString();
                leftOperand = result;
            }
        }

        // this is used to calculate the special operators like 1\x, sqr, sqrt, negate
        private void CalcSpecial (string name, float power) {
            switch (calculatorState) {
                case 0:
                    updateTxtPrevious(String.Format("{0}(0)", name));
                    if (power == -1) {
                        SetErrorState("Cannot divide by zero");
                    }
                    else {
                        txt_output.Text = Math.Pow(0, power).ToString();
                        calculatorState = 5;
                    }
                    break;
                case 1:
                    updateTxtPrevious(String.Format("{0}({1})", name, currentEntry));
                    txt_output.Text = Math.Pow(double.Parse(currentEntry.ToString()), power).ToString();
                    calculatorState = 5;
                    break;
                case 2:
                    if (leftOperand == 0 && power == -1)
                        SetErrorState("Cannot divide by zero");
                    else {
                        updateTxtPrevious(String.Format("{0} {1} {2}({3})", leftOperand, operMap[oper], name, leftOperand));
                        txt_output.Text = Math.Pow((double)leftOperand, power).ToString();
                        calculatorState = 6;
                    }
                    break;
                case 3:
                    if (currentEntry.ToString() == "0" && power == -1)
                        SetErrorState("Cannot divide by zero");
                    else {
                        updateTxtPrevious(String.Format("{0} {1} {2}({3})", leftOperand, operMap[oper], name, txt_output.Text));
                        txt_output.Text = Math.Pow(double.Parse(currentEntry.ToString()), power).ToString();
                        calculatorState = 6;
                    }
                    break;
                case 4:
                    if (previousOperation == 0 && power == -1)
                        SetErrorState("Cannot divide by zero");
                    else {
                        updateTxtPrevious(String.Format("{0}({1})", name, previousOperation));
                        txt_output.Text = Math.Pow((double)previousOperation, power).ToString();
                        leftOperand = null;
                        previousOperation = null;
                        rightOperand = null;
                        oper = null;
                        currentEntry.Clear();
                        calculatorState = 5;
                    }
                    break;
                case 5:
                    updateTxtPrevious(String.Format("{0}({1})", name, txt_output.Text));
                    txt_output.Text = Math.Pow(double.Parse(txt_output.Text), power).ToString();
                    calculatorState = 5;
                    break;
                case 6:
                    updateTxtPrevious(String.Format("{0} {1} {2}({3})", leftOperand, operMap[oper], name, txt_output.Text));
                    txt_output.Text = Math.Pow(double.Parse(txt_output.Text), power).ToString();
                    calculatorState = 6;
                    break;
            }
        }

        // used when an operator is pressed
        private void CalcOperator(int opCode) {
            if (currentEntry.Length > 0 && currentEntry[currentEntry.Length-1] == '.') {
                btn_del_Click(new object(), new EventArgs());
            }

            float? retVal;
            switch (calculatorState) {
                case 0:
                    oper = opCode;
                    leftOperand = 0;
                    calculatorState = 2;
                    break;
                case 1:
                    oper = opCode;
                    leftOperand = float.Parse(currentEntry.ToString());
                    currentEntry.Clear();
                    calculatorState = 2;
                    break;
                case 2:
                    oper = opCode;
                    break;
                case 3:
                    // will run an equals operation and set the screen occordingly
                    rightOperand = float.Parse(currentEntry.ToString());

                    retVal = DoOperator();
                    if (retVal == null)
                        SetErrorState("Invalid Input");
                    else {
                        AddHistory(String.Format("{0} {1} = {2}", txt_prev.Text, rightOperand, retVal));
                        leftOperand = retVal;
                        rightOperand = null;
                        oper = opCode;

                        currentEntry.Clear();
                        txt_output.Text = retVal.ToString();
                        calculatorState = 2;
                    }
                    break;
                case 4:
                    if (oper == null) 
                        leftOperand = previousOperation;
                    previousOperation = null;
                    rightOperand = null;
                    currentEntry.Clear();
                    calculatorState = 2;
                    break;
                case 5:
                    leftOperand = float.Parse(txt_output.Text);
                    calculatorState = 2;
                    currentEntry.Clear();
                    break;
                case 6:
                    // will run the operation and enter into a waiting state
                    rightOperand = float.Parse(txt_output.Text);

                    retVal = DoOperator();
                    if (retVal == null)
                        SetErrorState("Invalid Input");
                    else {
                        AddHistory(txt_prev.Text);
                        leftOperand = retVal;
                        oper = opCode;

                        currentEntry.Clear();
                        txt_output.Text = retVal.ToString();
                        calculatorState = 2;
                    }
                    break;
            }
            if (calculatorState != -1) {
                updateTxtPrevious(leftOperand.ToString() + " " + operMap[opCode]);
                oper = opCode;
            }
        }

        // calculate the return value from the operation
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
                    retVal = rightOperand == 0 ? null : leftOperand / rightOperand;
                    break;
                case 4:
                    retVal = (float?)Math.Pow((double)leftOperand, (double)rightOperand);
                    break;
            }
            return retVal;
        }

        // maps key press events to button presses
        void Calculator_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == '0')
                btn_0_Click(sender, e);
            else if (e.KeyChar >= '1' && e.KeyChar <= '9')
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
                btn_decimal_Click(sender, e);
            else if (e.KeyChar == '=')
                btn_equal_Click(sender, e);
            else if (e.KeyChar == 'c')
                btn_c_Click(sender, e);
            else if ((int)e.KeyChar == 8)
                btn_del_Click(sender, e);
            else if ((int)e.KeyChar == 27)
                btn_c_Click(sender, e);
        }

        // adds the input to the string buffer
        private void addInput(char numb) {
            if (calculatorState == 4) {
                currentEntry.Clear();
                calculatorState = 0;
            }
            // allows for up to 16 characters to be entered
            if (currentEntry.Length < 16) {
                currentEntry.Append(numb);

                if (calculatorState == -1)
                    calculatorState = 1;
                else if (calculatorState == 0) 
                    calculatorState = 1;
                else if (calculatorState == 2)
                    calculatorState = 3;

                updateOutput();
            }
        }

        // updates the output text box
        private void updateOutput() {
            txt_output.Text = currentEntry.ToString();
            if (currentEntry.Length == 0) {
                resetOutput();
            }
        }

        // updates the previous text box with string txt
        private void updateTxtPrevious (string txt) {
            txt_prev.Text = txt;
        }

        // resets the output
        private void resetOutput() {
            txt_output.Text = "0";
            currentEntry.Clear();
        }

        // resets all variables
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

        // sets the error state
        private void SetErrorState(string err) {
            txt_output.Text = err;
            calculatorState = -1;
        }

        // saves the history to the rich text field
        private void AddHistory(string hist) {
            txt_history.Text += hist + '\n';
        }
    }
}
