//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 3.5.0.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// $ANTLR 3.5.0.2 expression.g3 1435-05-29 10:18:22

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162
// Missing XML comment for publicly visible type or member 'Type_or_Member'
#pragma warning disable 1591
// CLS compliance checking will not be performed on 'type' because it is not visible from outside this assembly.
#pragma warning disable 3019


using System.Collections.Generic;
using Antlr.Runtime;
using Antlr.Runtime.Misc;

namespace Sketcher.Drawing.Expressions
{
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.5.0.2")]
[System.CLSCompliant(false)]
internal partial class expressionLexer : Antlr.Runtime.Lexer
{
	public const int EOF=-1;
	public const int IDINTIFIER=4;
	public const int LPARN=5;
	public const int NUMBER=6;
	public const int RPARN=7;
	public const int WS=8;
	public const int T__9=9;
	public const int T__10=10;
	public const int T__11=11;
	public const int T__12=12;
	public const int T__13=13;
	public const int T__14=14;
	public const int T__15=15;
	public const int T__16=16;
	public const int T__17=17;
	public const int T__18=18;
	public const int T__19=19;
	public const int T__20=20;
	public const int T__21=21;
	public const int T__22=22;
	public const int T__23=23;

	// delegates
	// delegators

	public expressionLexer()
	{
		OnCreated();
	}

	public expressionLexer(ICharStream input )
		: this(input, new RecognizerSharedState())
	{
	}

	public expressionLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state)
	{

		OnCreated();
	}
	public override string GrammarFileName { get { return "expression.g3"; } }


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	partial void EnterRule_LPARN();
	partial void LeaveRule_LPARN();

	// $ANTLR start "LPARN"
	[GrammarRule("LPARN")]
	private void mLPARN()
	{
		EnterRule_LPARN();
		EnterRule("LPARN", 1);
		TraceIn("LPARN", 1);
		try
		{
			int _type = LPARN;
			int _channel = DefaultTokenChannel;
			// expression.g3:10:7: ( '(' )
			DebugEnterAlt(1);
			// expression.g3:10:9: '('
			{
			DebugLocation(10, 9);
			Match('('); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LPARN", 1);
			LeaveRule("LPARN", 1);
			LeaveRule_LPARN();
		}
	}
	// $ANTLR end "LPARN"

	partial void EnterRule_RPARN();
	partial void LeaveRule_RPARN();

	// $ANTLR start "RPARN"
	[GrammarRule("RPARN")]
	private void mRPARN()
	{
		EnterRule_RPARN();
		EnterRule("RPARN", 2);
		TraceIn("RPARN", 2);
		try
		{
			int _type = RPARN;
			int _channel = DefaultTokenChannel;
			// expression.g3:11:7: ( ')' )
			DebugEnterAlt(1);
			// expression.g3:11:9: ')'
			{
			DebugLocation(11, 9);
			Match(')'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("RPARN", 2);
			LeaveRule("RPARN", 2);
			LeaveRule_RPARN();
		}
	}
	// $ANTLR end "RPARN"

	partial void EnterRule_T__9();
	partial void LeaveRule_T__9();

	// $ANTLR start "T__9"
	[GrammarRule("T__9")]
	private void mT__9()
	{
		EnterRule_T__9();
		EnterRule("T__9", 3);
		TraceIn("T__9", 3);
		try
		{
			int _type = T__9;
			int _channel = DefaultTokenChannel;
			// expression.g3:12:6: ( '!=' )
			DebugEnterAlt(1);
			// expression.g3:12:8: '!='
			{
			DebugLocation(12, 8);
			Match("!="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__9", 3);
			LeaveRule("T__9", 3);
			LeaveRule_T__9();
		}
	}
	// $ANTLR end "T__9"

	partial void EnterRule_T__10();
	partial void LeaveRule_T__10();

	// $ANTLR start "T__10"
	[GrammarRule("T__10")]
	private void mT__10()
	{
		EnterRule_T__10();
		EnterRule("T__10", 4);
		TraceIn("T__10", 4);
		try
		{
			int _type = T__10;
			int _channel = DefaultTokenChannel;
			// expression.g3:13:7: ( '%' )
			DebugEnterAlt(1);
			// expression.g3:13:9: '%'
			{
			DebugLocation(13, 9);
			Match('%'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__10", 4);
			LeaveRule("T__10", 4);
			LeaveRule_T__10();
		}
	}
	// $ANTLR end "T__10"

	partial void EnterRule_T__11();
	partial void LeaveRule_T__11();

	// $ANTLR start "T__11"
	[GrammarRule("T__11")]
	private void mT__11()
	{
		EnterRule_T__11();
		EnterRule("T__11", 5);
		TraceIn("T__11", 5);
		try
		{
			int _type = T__11;
			int _channel = DefaultTokenChannel;
			// expression.g3:14:7: ( '&' )
			DebugEnterAlt(1);
			// expression.g3:14:9: '&'
			{
			DebugLocation(14, 9);
			Match('&'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__11", 5);
			LeaveRule("T__11", 5);
			LeaveRule_T__11();
		}
	}
	// $ANTLR end "T__11"

	partial void EnterRule_T__12();
	partial void LeaveRule_T__12();

	// $ANTLR start "T__12"
	[GrammarRule("T__12")]
	private void mT__12()
	{
		EnterRule_T__12();
		EnterRule("T__12", 6);
		TraceIn("T__12", 6);
		try
		{
			int _type = T__12;
			int _channel = DefaultTokenChannel;
			// expression.g3:15:7: ( '*' )
			DebugEnterAlt(1);
			// expression.g3:15:9: '*'
			{
			DebugLocation(15, 9);
			Match('*'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__12", 6);
			LeaveRule("T__12", 6);
			LeaveRule_T__12();
		}
	}
	// $ANTLR end "T__12"

	partial void EnterRule_T__13();
	partial void LeaveRule_T__13();

	// $ANTLR start "T__13"
	[GrammarRule("T__13")]
	private void mT__13()
	{
		EnterRule_T__13();
		EnterRule("T__13", 7);
		TraceIn("T__13", 7);
		try
		{
			int _type = T__13;
			int _channel = DefaultTokenChannel;
			// expression.g3:16:7: ( '+' )
			DebugEnterAlt(1);
			// expression.g3:16:9: '+'
			{
			DebugLocation(16, 9);
			Match('+'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__13", 7);
			LeaveRule("T__13", 7);
			LeaveRule_T__13();
		}
	}
	// $ANTLR end "T__13"

	partial void EnterRule_T__14();
	partial void LeaveRule_T__14();

	// $ANTLR start "T__14"
	[GrammarRule("T__14")]
	private void mT__14()
	{
		EnterRule_T__14();
		EnterRule("T__14", 8);
		TraceIn("T__14", 8);
		try
		{
			int _type = T__14;
			int _channel = DefaultTokenChannel;
			// expression.g3:17:7: ( ',' )
			DebugEnterAlt(1);
			// expression.g3:17:9: ','
			{
			DebugLocation(17, 9);
			Match(','); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__14", 8);
			LeaveRule("T__14", 8);
			LeaveRule_T__14();
		}
	}
	// $ANTLR end "T__14"

	partial void EnterRule_T__15();
	partial void LeaveRule_T__15();

	// $ANTLR start "T__15"
	[GrammarRule("T__15")]
	private void mT__15()
	{
		EnterRule_T__15();
		EnterRule("T__15", 9);
		TraceIn("T__15", 9);
		try
		{
			int _type = T__15;
			int _channel = DefaultTokenChannel;
			// expression.g3:18:7: ( '-' )
			DebugEnterAlt(1);
			// expression.g3:18:9: '-'
			{
			DebugLocation(18, 9);
			Match('-'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__15", 9);
			LeaveRule("T__15", 9);
			LeaveRule_T__15();
		}
	}
	// $ANTLR end "T__15"

	partial void EnterRule_T__16();
	partial void LeaveRule_T__16();

	// $ANTLR start "T__16"
	[GrammarRule("T__16")]
	private void mT__16()
	{
		EnterRule_T__16();
		EnterRule("T__16", 10);
		TraceIn("T__16", 10);
		try
		{
			int _type = T__16;
			int _channel = DefaultTokenChannel;
			// expression.g3:19:7: ( '/' )
			DebugEnterAlt(1);
			// expression.g3:19:9: '/'
			{
			DebugLocation(19, 9);
			Match('/'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__16", 10);
			LeaveRule("T__16", 10);
			LeaveRule_T__16();
		}
	}
	// $ANTLR end "T__16"

	partial void EnterRule_T__17();
	partial void LeaveRule_T__17();

	// $ANTLR start "T__17"
	[GrammarRule("T__17")]
	private void mT__17()
	{
		EnterRule_T__17();
		EnterRule("T__17", 11);
		TraceIn("T__17", 11);
		try
		{
			int _type = T__17;
			int _channel = DefaultTokenChannel;
			// expression.g3:20:7: ( '<' )
			DebugEnterAlt(1);
			// expression.g3:20:9: '<'
			{
			DebugLocation(20, 9);
			Match('<'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__17", 11);
			LeaveRule("T__17", 11);
			LeaveRule_T__17();
		}
	}
	// $ANTLR end "T__17"

	partial void EnterRule_T__18();
	partial void LeaveRule_T__18();

	// $ANTLR start "T__18"
	[GrammarRule("T__18")]
	private void mT__18()
	{
		EnterRule_T__18();
		EnterRule("T__18", 12);
		TraceIn("T__18", 12);
		try
		{
			int _type = T__18;
			int _channel = DefaultTokenChannel;
			// expression.g3:21:7: ( '<=' )
			DebugEnterAlt(1);
			// expression.g3:21:9: '<='
			{
			DebugLocation(21, 9);
			Match("<="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__18", 12);
			LeaveRule("T__18", 12);
			LeaveRule_T__18();
		}
	}
	// $ANTLR end "T__18"

	partial void EnterRule_T__19();
	partial void LeaveRule_T__19();

	// $ANTLR start "T__19"
	[GrammarRule("T__19")]
	private void mT__19()
	{
		EnterRule_T__19();
		EnterRule("T__19", 13);
		TraceIn("T__19", 13);
		try
		{
			int _type = T__19;
			int _channel = DefaultTokenChannel;
			// expression.g3:22:7: ( '=' )
			DebugEnterAlt(1);
			// expression.g3:22:9: '='
			{
			DebugLocation(22, 9);
			Match('='); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__19", 13);
			LeaveRule("T__19", 13);
			LeaveRule_T__19();
		}
	}
	// $ANTLR end "T__19"

	partial void EnterRule_T__20();
	partial void LeaveRule_T__20();

	// $ANTLR start "T__20"
	[GrammarRule("T__20")]
	private void mT__20()
	{
		EnterRule_T__20();
		EnterRule("T__20", 14);
		TraceIn("T__20", 14);
		try
		{
			int _type = T__20;
			int _channel = DefaultTokenChannel;
			// expression.g3:23:7: ( '>' )
			DebugEnterAlt(1);
			// expression.g3:23:9: '>'
			{
			DebugLocation(23, 9);
			Match('>'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__20", 14);
			LeaveRule("T__20", 14);
			LeaveRule_T__20();
		}
	}
	// $ANTLR end "T__20"

	partial void EnterRule_T__21();
	partial void LeaveRule_T__21();

	// $ANTLR start "T__21"
	[GrammarRule("T__21")]
	private void mT__21()
	{
		EnterRule_T__21();
		EnterRule("T__21", 15);
		TraceIn("T__21", 15);
		try
		{
			int _type = T__21;
			int _channel = DefaultTokenChannel;
			// expression.g3:24:7: ( '>=' )
			DebugEnterAlt(1);
			// expression.g3:24:9: '>='
			{
			DebugLocation(24, 9);
			Match(">="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__21", 15);
			LeaveRule("T__21", 15);
			LeaveRule_T__21();
		}
	}
	// $ANTLR end "T__21"

	partial void EnterRule_T__22();
	partial void LeaveRule_T__22();

	// $ANTLR start "T__22"
	[GrammarRule("T__22")]
	private void mT__22()
	{
		EnterRule_T__22();
		EnterRule("T__22", 16);
		TraceIn("T__22", 16);
		try
		{
			int _type = T__22;
			int _channel = DefaultTokenChannel;
			// expression.g3:25:7: ( '^' )
			DebugEnterAlt(1);
			// expression.g3:25:9: '^'
			{
			DebugLocation(25, 9);
			Match('^'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__22", 16);
			LeaveRule("T__22", 16);
			LeaveRule_T__22();
		}
	}
	// $ANTLR end "T__22"

	partial void EnterRule_T__23();
	partial void LeaveRule_T__23();

	// $ANTLR start "T__23"
	[GrammarRule("T__23")]
	private void mT__23()
	{
		EnterRule_T__23();
		EnterRule("T__23", 17);
		TraceIn("T__23", 17);
		try
		{
			int _type = T__23;
			int _channel = DefaultTokenChannel;
			// expression.g3:26:7: ( '|' )
			DebugEnterAlt(1);
			// expression.g3:26:9: '|'
			{
			DebugLocation(26, 9);
			Match('|'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__23", 17);
			LeaveRule("T__23", 17);
			LeaveRule_T__23();
		}
	}
	// $ANTLR end "T__23"

	partial void EnterRule_WS();
	partial void LeaveRule_WS();

	// $ANTLR start "WS"
	[GrammarRule("WS")]
	private void mWS()
	{
		EnterRule_WS();
		EnterRule("WS", 18);
		TraceIn("WS", 18);
		try
		{
			int _type = WS;
			int _channel = DefaultTokenChannel;
			// expression.g3:58:5: ( ( ' ' | '\\t' | '\\n' | '\\r' | '\\b' ) )
			DebugEnterAlt(1);
			// expression.g3:
			{
			DebugLocation(58, 5);
			if ((input.LA(1)>='\b' && input.LA(1)<='\n')||input.LA(1)=='\r'||input.LA(1)==' ')
			{
				input.Consume();
			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;
			}


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("WS", 18);
			LeaveRule("WS", 18);
			LeaveRule_WS();
		}
	}
	// $ANTLR end "WS"

	partial void EnterRule_NUMBER();
	partial void LeaveRule_NUMBER();

	// $ANTLR start "NUMBER"
	[GrammarRule("NUMBER")]
	private void mNUMBER()
	{
		EnterRule_NUMBER();
		EnterRule("NUMBER", 19);
		TraceIn("NUMBER", 19);
		try
		{
			int _type = NUMBER;
			int _channel = DefaultTokenChannel;
			// expression.g3:61:7: ( ( '+' | '-' )? ( '0' .. '9' )+ ( '.' ( '0' .. '9' )+ )? ( ( 'e' | 'E' ) ( '+' | '-' )? ( '0' .. '9' )+ )? )
			DebugEnterAlt(1);
			// expression.g3:62:2: ( '+' | '-' )? ( '0' .. '9' )+ ( '.' ( '0' .. '9' )+ )? ( ( 'e' | 'E' ) ( '+' | '-' )? ( '0' .. '9' )+ )?
			{
			DebugLocation(62, 2);
			// expression.g3:62:2: ( '+' | '-' )?
			int alt1=2;
			try { DebugEnterSubRule(1);
			try { DebugEnterDecision(1, false);
			int LA1_1 = input.LA(1);

			if ((LA1_1=='+'||LA1_1=='-'))
			{
				alt1 = 1;
			}
			} finally { DebugExitDecision(1); }
			switch (alt1)
			{
			case 1:
				DebugEnterAlt(1);
				// expression.g3:
				{
				DebugLocation(62, 2);
				input.Consume();


				}
				break;

			}
			} finally { DebugExitSubRule(1); }

			DebugLocation(63, 5);
			// expression.g3:63:5: ( '0' .. '9' )+
			int cnt2=0;
			try { DebugEnterSubRule(2);
			while (true)
			{
				int alt2=2;
				try { DebugEnterDecision(2, false);
				int LA2_1 = input.LA(1);

				if (((LA2_1>='0' && LA2_1<='9')))
				{
					alt2 = 1;
				}


				} finally { DebugExitDecision(2); }
				switch (alt2)
				{
				case 1:
					DebugEnterAlt(1);
					// expression.g3:
					{
					DebugLocation(63, 5);
					input.Consume();


					}
					break;

				default:
					if (cnt2 >= 1)
						goto loop2;

					EarlyExitException eee2 = new EarlyExitException( 2, input );
					DebugRecognitionException(eee2);
					throw eee2;
				}
				cnt2++;
			}
			loop2:
				;

			} finally { DebugExitSubRule(2); }

			DebugLocation(64, 2);
			// expression.g3:64:2: ( '.' ( '0' .. '9' )+ )?
			int alt4=2;
			try { DebugEnterSubRule(4);
			try { DebugEnterDecision(4, false);
			int LA4_1 = input.LA(1);

			if ((LA4_1=='.'))
			{
				alt4 = 1;
			}
			} finally { DebugExitDecision(4); }
			switch (alt4)
			{
			case 1:
				DebugEnterAlt(1);
				// expression.g3:64:3: '.' ( '0' .. '9' )+
				{
				DebugLocation(64, 3);
				Match('.'); 
				DebugLocation(64, 10);
				// expression.g3:64:10: ( '0' .. '9' )+
				int cnt3=0;
				try { DebugEnterSubRule(3);
				while (true)
				{
					int alt3=2;
					try { DebugEnterDecision(3, false);
					int LA3_1 = input.LA(1);

					if (((LA3_1>='0' && LA3_1<='9')))
					{
						alt3 = 1;
					}


					} finally { DebugExitDecision(3); }
					switch (alt3)
					{
					case 1:
						DebugEnterAlt(1);
						// expression.g3:
						{
						DebugLocation(64, 10);
						input.Consume();


						}
						break;

					default:
						if (cnt3 >= 1)
							goto loop3;

						EarlyExitException eee3 = new EarlyExitException( 3, input );
						DebugRecognitionException(eee3);
						throw eee3;
					}
					cnt3++;
				}
				loop3:
					;

				} finally { DebugExitSubRule(3); }


				}
				break;

			}
			} finally { DebugExitSubRule(4); }

			DebugLocation(65, 2);
			// expression.g3:65:2: ( ( 'e' | 'E' ) ( '+' | '-' )? ( '0' .. '9' )+ )?
			int alt7=2;
			try { DebugEnterSubRule(7);
			try { DebugEnterDecision(7, false);
			int LA7_1 = input.LA(1);

			if ((LA7_1=='E'||LA7_1=='e'))
			{
				alt7 = 1;
			}
			} finally { DebugExitDecision(7); }
			switch (alt7)
			{
			case 1:
				DebugEnterAlt(1);
				// expression.g3:65:3: ( 'e' | 'E' ) ( '+' | '-' )? ( '0' .. '9' )+
				{
				DebugLocation(65, 3);
				input.Consume();

				DebugLocation(65, 15);
				// expression.g3:65:15: ( '+' | '-' )?
				int alt5=2;
				try { DebugEnterSubRule(5);
				try { DebugEnterDecision(5, false);
				int LA5_1 = input.LA(1);

				if ((LA5_1=='+'||LA5_1=='-'))
				{
					alt5 = 1;
				}
				} finally { DebugExitDecision(5); }
				switch (alt5)
				{
				case 1:
					DebugEnterAlt(1);
					// expression.g3:
					{
					DebugLocation(65, 15);
					input.Consume();


					}
					break;

				}
				} finally { DebugExitSubRule(5); }

				DebugLocation(65, 30);
				// expression.g3:65:30: ( '0' .. '9' )+
				int cnt6=0;
				try { DebugEnterSubRule(6);
				while (true)
				{
					int alt6=2;
					try { DebugEnterDecision(6, false);
					int LA6_1 = input.LA(1);

					if (((LA6_1>='0' && LA6_1<='9')))
					{
						alt6 = 1;
					}


					} finally { DebugExitDecision(6); }
					switch (alt6)
					{
					case 1:
						DebugEnterAlt(1);
						// expression.g3:
						{
						DebugLocation(65, 30);
						input.Consume();


						}
						break;

					default:
						if (cnt6 >= 1)
							goto loop6;

						EarlyExitException eee6 = new EarlyExitException( 6, input );
						DebugRecognitionException(eee6);
						throw eee6;
					}
					cnt6++;
				}
				loop6:
					;

				} finally { DebugExitSubRule(6); }


				}
				break;

			}
			} finally { DebugExitSubRule(7); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NUMBER", 19);
			LeaveRule("NUMBER", 19);
			LeaveRule_NUMBER();
		}
	}
	// $ANTLR end "NUMBER"

	partial void EnterRule_IDINTIFIER();
	partial void LeaveRule_IDINTIFIER();

	// $ANTLR start "IDINTIFIER"
	[GrammarRule("IDINTIFIER")]
	private void mIDINTIFIER()
	{
		EnterRule_IDINTIFIER();
		EnterRule("IDINTIFIER", 20);
		TraceIn("IDINTIFIER", 20);
		try
		{
			int _type = IDINTIFIER;
			int _channel = DefaultTokenChannel;
			// expression.g3:69:2: ( ( 'a' .. 'z' | 'A' .. 'Z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )* )
			DebugEnterAlt(1);
			// expression.g3:69:4: ( 'a' .. 'z' | 'A' .. 'Z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )*
			{
			DebugLocation(69, 4);
			if ((input.LA(1)>='A' && input.LA(1)<='Z')||(input.LA(1)>='a' && input.LA(1)<='z'))
			{
				input.Consume();
			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;
			}

			DebugLocation(69, 26);
			// expression.g3:69:26: ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )*
			try { DebugEnterSubRule(8);
			while (true)
			{
				int alt8=2;
				try { DebugEnterDecision(8, false);
				int LA8_1 = input.LA(1);

				if (((LA8_1>='0' && LA8_1<='9')||(LA8_1>='A' && LA8_1<='Z')||LA8_1=='_'||(LA8_1>='a' && LA8_1<='z')))
				{
					alt8 = 1;
				}


				} finally { DebugExitDecision(8); }
				switch ( alt8 )
				{
				case 1:
					DebugEnterAlt(1);
					// expression.g3:
					{
					DebugLocation(69, 26);
					input.Consume();


					}
					break;

				default:
					goto loop8;
				}
			}

			loop8:
				;

			} finally { DebugExitSubRule(8); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("IDINTIFIER", 20);
			LeaveRule("IDINTIFIER", 20);
			LeaveRule_IDINTIFIER();
		}
	}
	// $ANTLR end "IDINTIFIER"

	public override void mTokens()
	{
		// expression.g3:1:8: ( LPARN | RPARN | T__9 | T__10 | T__11 | T__12 | T__13 | T__14 | T__15 | T__16 | T__17 | T__18 | T__19 | T__20 | T__21 | T__22 | T__23 | WS | NUMBER | IDINTIFIER )
		int alt9=20;
		try { DebugEnterDecision(9, false);
		switch (input.LA(1))
		{
		case '(':
			{
			alt9 = 1;
			}
			break;
		case ')':
			{
			alt9 = 2;
			}
			break;
		case '!':
			{
			alt9 = 3;
			}
			break;
		case '%':
			{
			alt9 = 4;
			}
			break;
		case '&':
			{
			alt9 = 5;
			}
			break;
		case '*':
			{
			alt9 = 6;
			}
			break;
		case '+':
			{
			int LA9_2 = input.LA(2);

			if (((LA9_2>='0' && LA9_2<='9')))
			{
				alt9 = 19;
			}
			else
			{
				alt9 = 7;
			}
			}
			break;
		case ',':
			{
			alt9 = 8;
			}
			break;
		case '-':
			{
			int LA9_2 = input.LA(2);

			if (((LA9_2>='0' && LA9_2<='9')))
			{
				alt9 = 19;
			}
			else
			{
				alt9 = 9;
			}
			}
			break;
		case '/':
			{
			alt9 = 10;
			}
			break;
		case '<':
			{
			int LA9_2 = input.LA(2);

			if ((LA9_2=='='))
			{
				alt9 = 12;
			}
			else
			{
				alt9 = 11;
			}
			}
			break;
		case '=':
			{
			alt9 = 13;
			}
			break;
		case '>':
			{
			int LA9_2 = input.LA(2);

			if ((LA9_2=='='))
			{
				alt9 = 15;
			}
			else
			{
				alt9 = 14;
			}
			}
			break;
		case '^':
			{
			alt9 = 16;
			}
			break;
		case '|':
			{
			alt9 = 17;
			}
			break;
		case '\b':
		case '\t':
		case '\n':
		case '\r':
		case ' ':
			{
			alt9 = 18;
			}
			break;
		case '0':
		case '1':
		case '2':
		case '3':
		case '4':
		case '5':
		case '6':
		case '7':
		case '8':
		case '9':
			{
			alt9 = 19;
			}
			break;
		case 'A':
		case 'B':
		case 'C':
		case 'D':
		case 'E':
		case 'F':
		case 'G':
		case 'H':
		case 'I':
		case 'J':
		case 'K':
		case 'L':
		case 'M':
		case 'N':
		case 'O':
		case 'P':
		case 'Q':
		case 'R':
		case 'S':
		case 'T':
		case 'U':
		case 'V':
		case 'W':
		case 'X':
		case 'Y':
		case 'Z':
		case 'a':
		case 'b':
		case 'c':
		case 'd':
		case 'e':
		case 'f':
		case 'g':
		case 'h':
		case 'i':
		case 'j':
		case 'k':
		case 'l':
		case 'm':
		case 'n':
		case 'o':
		case 'p':
		case 'q':
		case 'r':
		case 's':
		case 't':
		case 'u':
		case 'v':
		case 'w':
		case 'x':
		case 'y':
		case 'z':
			{
			alt9 = 20;
			}
			break;
		default:
			{
				NoViableAltException nvae = new NoViableAltException("", 9, 0, input, 1);
				DebugRecognitionException(nvae);
				throw nvae;
			}
		}

		} finally { DebugExitDecision(9); }
		switch (alt9)
		{
		case 1:
			DebugEnterAlt(1);
			// expression.g3:1:10: LPARN
			{
			DebugLocation(1, 10);
			mLPARN(); 

			}
			break;
		case 2:
			DebugEnterAlt(2);
			// expression.g3:1:16: RPARN
			{
			DebugLocation(1, 16);
			mRPARN(); 

			}
			break;
		case 3:
			DebugEnterAlt(3);
			// expression.g3:1:22: T__9
			{
			DebugLocation(1, 22);
			mT__9(); 

			}
			break;
		case 4:
			DebugEnterAlt(4);
			// expression.g3:1:27: T__10
			{
			DebugLocation(1, 27);
			mT__10(); 

			}
			break;
		case 5:
			DebugEnterAlt(5);
			// expression.g3:1:33: T__11
			{
			DebugLocation(1, 33);
			mT__11(); 

			}
			break;
		case 6:
			DebugEnterAlt(6);
			// expression.g3:1:39: T__12
			{
			DebugLocation(1, 39);
			mT__12(); 

			}
			break;
		case 7:
			DebugEnterAlt(7);
			// expression.g3:1:45: T__13
			{
			DebugLocation(1, 45);
			mT__13(); 

			}
			break;
		case 8:
			DebugEnterAlt(8);
			// expression.g3:1:51: T__14
			{
			DebugLocation(1, 51);
			mT__14(); 

			}
			break;
		case 9:
			DebugEnterAlt(9);
			// expression.g3:1:57: T__15
			{
			DebugLocation(1, 57);
			mT__15(); 

			}
			break;
		case 10:
			DebugEnterAlt(10);
			// expression.g3:1:63: T__16
			{
			DebugLocation(1, 63);
			mT__16(); 

			}
			break;
		case 11:
			DebugEnterAlt(11);
			// expression.g3:1:69: T__17
			{
			DebugLocation(1, 69);
			mT__17(); 

			}
			break;
		case 12:
			DebugEnterAlt(12);
			// expression.g3:1:75: T__18
			{
			DebugLocation(1, 75);
			mT__18(); 

			}
			break;
		case 13:
			DebugEnterAlt(13);
			// expression.g3:1:81: T__19
			{
			DebugLocation(1, 81);
			mT__19(); 

			}
			break;
		case 14:
			DebugEnterAlt(14);
			// expression.g3:1:87: T__20
			{
			DebugLocation(1, 87);
			mT__20(); 

			}
			break;
		case 15:
			DebugEnterAlt(15);
			// expression.g3:1:93: T__21
			{
			DebugLocation(1, 93);
			mT__21(); 

			}
			break;
		case 16:
			DebugEnterAlt(16);
			// expression.g3:1:99: T__22
			{
			DebugLocation(1, 99);
			mT__22(); 

			}
			break;
		case 17:
			DebugEnterAlt(17);
			// expression.g3:1:105: T__23
			{
			DebugLocation(1, 105);
			mT__23(); 

			}
			break;
		case 18:
			DebugEnterAlt(18);
			// expression.g3:1:111: WS
			{
			DebugLocation(1, 111);
			mWS(); 

			}
			break;
		case 19:
			DebugEnterAlt(19);
			// expression.g3:1:114: NUMBER
			{
			DebugLocation(1, 114);
			mNUMBER(); 

			}
			break;
		case 20:
			DebugEnterAlt(20);
			// expression.g3:1:121: IDINTIFIER
			{
			DebugLocation(1, 121);
			mIDINTIFIER(); 

			}
			break;

		}

	}


	#region DFA

	protected override void InitDFAs()
	{
		base.InitDFAs();
	}

	#endregion

}

} // namespace Sketcher.Expression
