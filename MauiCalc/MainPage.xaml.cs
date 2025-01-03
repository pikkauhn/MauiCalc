namespace MauiCalc;

public partial class MainPage : ContentPage
{
	private string _result = "0";
	private string _currentOperand = "";
	private string _operator = "";

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnNumberButtonClicked(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		string digit = button.Text;

		if (_result == "0")
		{
			_result = digit;
		}
		else
		{
			_result += digit;
		}
		ResultEntry.Text = _result;
	}

	private void OnOperatorButtonClicked(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		_operator = button.Text;
		_currentOperand = _result;
		_result = "0";
	}

	private void OnClearButtonClicked(object sender, EventArgs e)
	{
		_result = "0";
		_currentOperand = "";
		_operator = "";
		ResultEntry.Text = _result;
	}

	private void OnCalculateButtonClicked(object sender, EventArgs e)
	{
		if (double.TryParse(_currentOperand, out double operand1) &&
			double.TryParse(_result, out double operand2))
		{
			double result = 0;

			switch (_operator)
			{
				case "+":
					result = operand1 + operand2;
					break;
				case "-":
					result = operand1 - operand2;
					break;
				case "*":
					result = operand1 * operand2;
					break;
				case "/":
					if (operand2 == 0)
					{
						ResultEntry.Text = "Error";
						return;
					}
					result = operand1 / operand2;
					break;
			}
			_result = result.ToString();
			ResultEntry.Text = _result;
		}
		else
		{
			ResultEntry.Text = "Error";
		}
	}
}



