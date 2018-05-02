using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class TuringMachine {
	Dictionary<string, string> rules;
	int[] finalState;
	int state;
	int position;
	string tira;

	public TuringMachine(string tira, Dictionary<string, string> rules, int[] finalState)
	{
		this.tira = tira;
		this.rules = rules;
		this.finalState = finalState;
		state = 0;
		position = 3;
	}

	private string GetSymbol()
	{
		return tira[position].ToString();
	}

	private void AddSymbol(){
		tira += "β";
	}

	public void WorkMachine(ref bool error, ref char dir, ref int state, ref bool end, ref char text, ref bool add)
	{
		if (rules.ContainsKey(state + GetSymbol()))
		{
			dir = rules[state + GetSymbol()][1];
			this.state = int.Parse(rules[state + GetSymbol()].Substring(2,rules[state + GetSymbol()].Length - 2).ToString());
			text = rules[state + GetSymbol()][0];
			state = this.state;

			if(tira[position] == 'β' && text != 'β'){
				AddSymbol();
				add = true;
			}

			StringBuilder remplace = new StringBuilder(tira);
			remplace[position] = text;
			tira = remplace.ToString();

			if (finalState.Contains(state))
				end = true;

			if (dir == 'R')
				position++;

			if (dir == 'L')               
				position--;
		}
		else {
			error = true;
		}
	}
}
