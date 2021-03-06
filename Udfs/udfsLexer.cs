//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 3.5.0.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// $ANTLR 3.5.0.2 udfs.g3 1435-06-18 15:42:21

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

namespace Sketcher.Udfs.Lexer
{
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.5.0.2")]
[System.CLSCompliant(false)]
public partial class udfsLexer : Antlr.Runtime.Lexer
{
	public const int EOF=-1;
	public const int COMMENT=4;
	public const int CONST=5;
	public const int ELSE=6;
	public const int FUNCTION_CALL=7;
	public const int FUNCTION_DECL=8;
	public const int GLOBAL=9;
	public const int IDINTIFIER=10;
	public const int IF=11;
	public const int LBRCT=12;
	public const int LPARN=13;
	public const int NLINE=14;
	public const int NUMBER=15;
	public const int RBRCT=16;
	public const int RET=17;
	public const int RPARN=18;
	public const int VAR=19;
	public const int WHILE=20;
	public const int WS=21;
	public const int T__22=22;
	public const int T__23=23;
	public const int T__24=24;
	public const int T__25=25;
	public const int T__26=26;
	public const int T__27=27;
	public const int T__28=28;
	public const int T__29=29;
	public const int T__30=30;
	public const int T__31=31;
	public const int T__32=32;
	public const int T__33=33;
	public const int T__34=34;
	public const int T__35=35;
	public const int T__36=36;
	public const int T__37=37;

	// delegates
	// delegators

	public udfsLexer()
	{
		OnCreated();
	}

	public udfsLexer(ICharStream input )
		: this(input, new RecognizerSharedState())
	{
	}

	public udfsLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state)
	{

		OnCreated();
	}
	public override string GrammarFileName { get { return "udfs.g3"; } }


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	partial void EnterRule_CONST();
	partial void LeaveRule_CONST();

	// $ANTLR start "CONST"
	[GrammarRule("CONST")]
	private void mCONST()
	{
		EnterRule_CONST();
		EnterRule("CONST", 1);
		TraceIn("CONST", 1);
		try
		{
			int _type = CONST;
			int _channel = DefaultTokenChannel;
			// udfs.g3:10:7: ( 'const' )
			DebugEnterAlt(1);
			// udfs.g3:10:9: 'const'
			{
			DebugLocation(10, 9);
			Match("const"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("CONST", 1);
			LeaveRule("CONST", 1);
			LeaveRule_CONST();
		}
	}
	// $ANTLR end "CONST"

	partial void EnterRule_ELSE();
	partial void LeaveRule_ELSE();

	// $ANTLR start "ELSE"
	[GrammarRule("ELSE")]
	private void mELSE()
	{
		EnterRule_ELSE();
		EnterRule("ELSE", 2);
		TraceIn("ELSE", 2);
		try
		{
			int _type = ELSE;
			int _channel = DefaultTokenChannel;
			// udfs.g3:11:6: ( 'else' )
			DebugEnterAlt(1);
			// udfs.g3:11:8: 'else'
			{
			DebugLocation(11, 8);
			Match("else"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ELSE", 2);
			LeaveRule("ELSE", 2);
			LeaveRule_ELSE();
		}
	}
	// $ANTLR end "ELSE"

	partial void EnterRule_FUNCTION_DECL();
	partial void LeaveRule_FUNCTION_DECL();

	// $ANTLR start "FUNCTION_DECL"
	[GrammarRule("FUNCTION_DECL")]
	private void mFUNCTION_DECL()
	{
		EnterRule_FUNCTION_DECL();
		EnterRule("FUNCTION_DECL", 3);
		TraceIn("FUNCTION_DECL", 3);
		try
		{
			int _type = FUNCTION_DECL;
			int _channel = DefaultTokenChannel;
			// udfs.g3:12:15: ( 'function' )
			DebugEnterAlt(1);
			// udfs.g3:12:17: 'function'
			{
			DebugLocation(12, 17);
			Match("function"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("FUNCTION_DECL", 3);
			LeaveRule("FUNCTION_DECL", 3);
			LeaveRule_FUNCTION_DECL();
		}
	}
	// $ANTLR end "FUNCTION_DECL"

	partial void EnterRule_GLOBAL();
	partial void LeaveRule_GLOBAL();

	// $ANTLR start "GLOBAL"
	[GrammarRule("GLOBAL")]
	private void mGLOBAL()
	{
		EnterRule_GLOBAL();
		EnterRule("GLOBAL", 4);
		TraceIn("GLOBAL", 4);
		try
		{
			int _type = GLOBAL;
			int _channel = DefaultTokenChannel;
			// udfs.g3:13:8: ( 'global' )
			DebugEnterAlt(1);
			// udfs.g3:13:10: 'global'
			{
			DebugLocation(13, 10);
			Match("global"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("GLOBAL", 4);
			LeaveRule("GLOBAL", 4);
			LeaveRule_GLOBAL();
		}
	}
	// $ANTLR end "GLOBAL"

	partial void EnterRule_IF();
	partial void LeaveRule_IF();

	// $ANTLR start "IF"
	[GrammarRule("IF")]
	private void mIF()
	{
		EnterRule_IF();
		EnterRule("IF", 5);
		TraceIn("IF", 5);
		try
		{
			int _type = IF;
			int _channel = DefaultTokenChannel;
			// udfs.g3:14:4: ( 'if' )
			DebugEnterAlt(1);
			// udfs.g3:14:6: 'if'
			{
			DebugLocation(14, 6);
			Match("if"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("IF", 5);
			LeaveRule("IF", 5);
			LeaveRule_IF();
		}
	}
	// $ANTLR end "IF"

	partial void EnterRule_LBRCT();
	partial void LeaveRule_LBRCT();

	// $ANTLR start "LBRCT"
	[GrammarRule("LBRCT")]
	private void mLBRCT()
	{
		EnterRule_LBRCT();
		EnterRule("LBRCT", 6);
		TraceIn("LBRCT", 6);
		try
		{
			int _type = LBRCT;
			int _channel = DefaultTokenChannel;
			// udfs.g3:15:7: ( '{' )
			DebugEnterAlt(1);
			// udfs.g3:15:9: '{'
			{
			DebugLocation(15, 9);
			Match('{'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LBRCT", 6);
			LeaveRule("LBRCT", 6);
			LeaveRule_LBRCT();
		}
	}
	// $ANTLR end "LBRCT"

	partial void EnterRule_LPARN();
	partial void LeaveRule_LPARN();

	// $ANTLR start "LPARN"
	[GrammarRule("LPARN")]
	private void mLPARN()
	{
		EnterRule_LPARN();
		EnterRule("LPARN", 7);
		TraceIn("LPARN", 7);
		try
		{
			int _type = LPARN;
			int _channel = DefaultTokenChannel;
			// udfs.g3:16:7: ( '(' )
			DebugEnterAlt(1);
			// udfs.g3:16:9: '('
			{
			DebugLocation(16, 9);
			Match('('); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LPARN", 7);
			LeaveRule("LPARN", 7);
			LeaveRule_LPARN();
		}
	}
	// $ANTLR end "LPARN"

	partial void EnterRule_RBRCT();
	partial void LeaveRule_RBRCT();

	// $ANTLR start "RBRCT"
	[GrammarRule("RBRCT")]
	private void mRBRCT()
	{
		EnterRule_RBRCT();
		EnterRule("RBRCT", 8);
		TraceIn("RBRCT", 8);
		try
		{
			int _type = RBRCT;
			int _channel = DefaultTokenChannel;
			// udfs.g3:17:7: ( '}' )
			DebugEnterAlt(1);
			// udfs.g3:17:9: '}'
			{
			DebugLocation(17, 9);
			Match('}'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("RBRCT", 8);
			LeaveRule("RBRCT", 8);
			LeaveRule_RBRCT();
		}
	}
	// $ANTLR end "RBRCT"

	partial void EnterRule_RET();
	partial void LeaveRule_RET();

	// $ANTLR start "RET"
	[GrammarRule("RET")]
	private void mRET()
	{
		EnterRule_RET();
		EnterRule("RET", 9);
		TraceIn("RET", 9);
		try
		{
			int _type = RET;
			int _channel = DefaultTokenChannel;
			// udfs.g3:18:5: ( 'resultis' )
			DebugEnterAlt(1);
			// udfs.g3:18:7: 'resultis'
			{
			DebugLocation(18, 7);
			Match("resultis"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("RET", 9);
			LeaveRule("RET", 9);
			LeaveRule_RET();
		}
	}
	// $ANTLR end "RET"

	partial void EnterRule_RPARN();
	partial void LeaveRule_RPARN();

	// $ANTLR start "RPARN"
	[GrammarRule("RPARN")]
	private void mRPARN()
	{
		EnterRule_RPARN();
		EnterRule("RPARN", 10);
		TraceIn("RPARN", 10);
		try
		{
			int _type = RPARN;
			int _channel = DefaultTokenChannel;
			// udfs.g3:19:7: ( ')' )
			DebugEnterAlt(1);
			// udfs.g3:19:9: ')'
			{
			DebugLocation(19, 9);
			Match(')'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("RPARN", 10);
			LeaveRule("RPARN", 10);
			LeaveRule_RPARN();
		}
	}
	// $ANTLR end "RPARN"

	partial void EnterRule_VAR();
	partial void LeaveRule_VAR();

	// $ANTLR start "VAR"
	[GrammarRule("VAR")]
	private void mVAR()
	{
		EnterRule_VAR();
		EnterRule("VAR", 11);
		TraceIn("VAR", 11);
		try
		{
			int _type = VAR;
			int _channel = DefaultTokenChannel;
			// udfs.g3:20:5: ( 'declvar' )
			DebugEnterAlt(1);
			// udfs.g3:20:7: 'declvar'
			{
			DebugLocation(20, 7);
			Match("declvar"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("VAR", 11);
			LeaveRule("VAR", 11);
			LeaveRule_VAR();
		}
	}
	// $ANTLR end "VAR"

	partial void EnterRule_WHILE();
	partial void LeaveRule_WHILE();

	// $ANTLR start "WHILE"
	[GrammarRule("WHILE")]
	private void mWHILE()
	{
		EnterRule_WHILE();
		EnterRule("WHILE", 12);
		TraceIn("WHILE", 12);
		try
		{
			int _type = WHILE;
			int _channel = DefaultTokenChannel;
			// udfs.g3:21:7: ( 'while' )
			DebugEnterAlt(1);
			// udfs.g3:21:9: 'while'
			{
			DebugLocation(21, 9);
			Match("while"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("WHILE", 12);
			LeaveRule("WHILE", 12);
			LeaveRule_WHILE();
		}
	}
	// $ANTLR end "WHILE"

	partial void EnterRule_T__22();
	partial void LeaveRule_T__22();

	// $ANTLR start "T__22"
	[GrammarRule("T__22")]
	private void mT__22()
	{
		EnterRule_T__22();
		EnterRule("T__22", 13);
		TraceIn("T__22", 13);
		try
		{
			int _type = T__22;
			int _channel = DefaultTokenChannel;
			// udfs.g3:22:7: ( '!=' )
			DebugEnterAlt(1);
			// udfs.g3:22:9: '!='
			{
			DebugLocation(22, 9);
			Match("!="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__22", 13);
			LeaveRule("T__22", 13);
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
		EnterRule("T__23", 14);
		TraceIn("T__23", 14);
		try
		{
			int _type = T__23;
			int _channel = DefaultTokenChannel;
			// udfs.g3:23:7: ( '%' )
			DebugEnterAlt(1);
			// udfs.g3:23:9: '%'
			{
			DebugLocation(23, 9);
			Match('%'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__23", 14);
			LeaveRule("T__23", 14);
			LeaveRule_T__23();
		}
	}
	// $ANTLR end "T__23"

	partial void EnterRule_T__24();
	partial void LeaveRule_T__24();

	// $ANTLR start "T__24"
	[GrammarRule("T__24")]
	private void mT__24()
	{
		EnterRule_T__24();
		EnterRule("T__24", 15);
		TraceIn("T__24", 15);
		try
		{
			int _type = T__24;
			int _channel = DefaultTokenChannel;
			// udfs.g3:24:7: ( '&' )
			DebugEnterAlt(1);
			// udfs.g3:24:9: '&'
			{
			DebugLocation(24, 9);
			Match('&'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__24", 15);
			LeaveRule("T__24", 15);
			LeaveRule_T__24();
		}
	}
	// $ANTLR end "T__24"

	partial void EnterRule_T__25();
	partial void LeaveRule_T__25();

	// $ANTLR start "T__25"
	[GrammarRule("T__25")]
	private void mT__25()
	{
		EnterRule_T__25();
		EnterRule("T__25", 16);
		TraceIn("T__25", 16);
		try
		{
			int _type = T__25;
			int _channel = DefaultTokenChannel;
			// udfs.g3:25:7: ( '*' )
			DebugEnterAlt(1);
			// udfs.g3:25:9: '*'
			{
			DebugLocation(25, 9);
			Match('*'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__25", 16);
			LeaveRule("T__25", 16);
			LeaveRule_T__25();
		}
	}
	// $ANTLR end "T__25"

	partial void EnterRule_T__26();
	partial void LeaveRule_T__26();

	// $ANTLR start "T__26"
	[GrammarRule("T__26")]
	private void mT__26()
	{
		EnterRule_T__26();
		EnterRule("T__26", 17);
		TraceIn("T__26", 17);
		try
		{
			int _type = T__26;
			int _channel = DefaultTokenChannel;
			// udfs.g3:26:7: ( '+' )
			DebugEnterAlt(1);
			// udfs.g3:26:9: '+'
			{
			DebugLocation(26, 9);
			Match('+'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__26", 17);
			LeaveRule("T__26", 17);
			LeaveRule_T__26();
		}
	}
	// $ANTLR end "T__26"

	partial void EnterRule_T__27();
	partial void LeaveRule_T__27();

	// $ANTLR start "T__27"
	[GrammarRule("T__27")]
	private void mT__27()
	{
		EnterRule_T__27();
		EnterRule("T__27", 18);
		TraceIn("T__27", 18);
		try
		{
			int _type = T__27;
			int _channel = DefaultTokenChannel;
			// udfs.g3:27:7: ( ',' )
			DebugEnterAlt(1);
			// udfs.g3:27:9: ','
			{
			DebugLocation(27, 9);
			Match(','); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__27", 18);
			LeaveRule("T__27", 18);
			LeaveRule_T__27();
		}
	}
	// $ANTLR end "T__27"

	partial void EnterRule_T__28();
	partial void LeaveRule_T__28();

	// $ANTLR start "T__28"
	[GrammarRule("T__28")]
	private void mT__28()
	{
		EnterRule_T__28();
		EnterRule("T__28", 19);
		TraceIn("T__28", 19);
		try
		{
			int _type = T__28;
			int _channel = DefaultTokenChannel;
			// udfs.g3:28:7: ( '-' )
			DebugEnterAlt(1);
			// udfs.g3:28:9: '-'
			{
			DebugLocation(28, 9);
			Match('-'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__28", 19);
			LeaveRule("T__28", 19);
			LeaveRule_T__28();
		}
	}
	// $ANTLR end "T__28"

	partial void EnterRule_T__29();
	partial void LeaveRule_T__29();

	// $ANTLR start "T__29"
	[GrammarRule("T__29")]
	private void mT__29()
	{
		EnterRule_T__29();
		EnterRule("T__29", 20);
		TraceIn("T__29", 20);
		try
		{
			int _type = T__29;
			int _channel = DefaultTokenChannel;
			// udfs.g3:29:7: ( '/' )
			DebugEnterAlt(1);
			// udfs.g3:29:9: '/'
			{
			DebugLocation(29, 9);
			Match('/'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__29", 20);
			LeaveRule("T__29", 20);
			LeaveRule_T__29();
		}
	}
	// $ANTLR end "T__29"

	partial void EnterRule_T__30();
	partial void LeaveRule_T__30();

	// $ANTLR start "T__30"
	[GrammarRule("T__30")]
	private void mT__30()
	{
		EnterRule_T__30();
		EnterRule("T__30", 21);
		TraceIn("T__30", 21);
		try
		{
			int _type = T__30;
			int _channel = DefaultTokenChannel;
			// udfs.g3:30:7: ( ':=' )
			DebugEnterAlt(1);
			// udfs.g3:30:9: ':='
			{
			DebugLocation(30, 9);
			Match(":="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__30", 21);
			LeaveRule("T__30", 21);
			LeaveRule_T__30();
		}
	}
	// $ANTLR end "T__30"

	partial void EnterRule_T__31();
	partial void LeaveRule_T__31();

	// $ANTLR start "T__31"
	[GrammarRule("T__31")]
	private void mT__31()
	{
		EnterRule_T__31();
		EnterRule("T__31", 22);
		TraceIn("T__31", 22);
		try
		{
			int _type = T__31;
			int _channel = DefaultTokenChannel;
			// udfs.g3:31:7: ( '<' )
			DebugEnterAlt(1);
			// udfs.g3:31:9: '<'
			{
			DebugLocation(31, 9);
			Match('<'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__31", 22);
			LeaveRule("T__31", 22);
			LeaveRule_T__31();
		}
	}
	// $ANTLR end "T__31"

	partial void EnterRule_T__32();
	partial void LeaveRule_T__32();

	// $ANTLR start "T__32"
	[GrammarRule("T__32")]
	private void mT__32()
	{
		EnterRule_T__32();
		EnterRule("T__32", 23);
		TraceIn("T__32", 23);
		try
		{
			int _type = T__32;
			int _channel = DefaultTokenChannel;
			// udfs.g3:32:7: ( '<=' )
			DebugEnterAlt(1);
			// udfs.g3:32:9: '<='
			{
			DebugLocation(32, 9);
			Match("<="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__32", 23);
			LeaveRule("T__32", 23);
			LeaveRule_T__32();
		}
	}
	// $ANTLR end "T__32"

	partial void EnterRule_T__33();
	partial void LeaveRule_T__33();

	// $ANTLR start "T__33"
	[GrammarRule("T__33")]
	private void mT__33()
	{
		EnterRule_T__33();
		EnterRule("T__33", 24);
		TraceIn("T__33", 24);
		try
		{
			int _type = T__33;
			int _channel = DefaultTokenChannel;
			// udfs.g3:33:7: ( '=' )
			DebugEnterAlt(1);
			// udfs.g3:33:9: '='
			{
			DebugLocation(33, 9);
			Match('='); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__33", 24);
			LeaveRule("T__33", 24);
			LeaveRule_T__33();
		}
	}
	// $ANTLR end "T__33"

	partial void EnterRule_T__34();
	partial void LeaveRule_T__34();

	// $ANTLR start "T__34"
	[GrammarRule("T__34")]
	private void mT__34()
	{
		EnterRule_T__34();
		EnterRule("T__34", 25);
		TraceIn("T__34", 25);
		try
		{
			int _type = T__34;
			int _channel = DefaultTokenChannel;
			// udfs.g3:34:7: ( '>' )
			DebugEnterAlt(1);
			// udfs.g3:34:9: '>'
			{
			DebugLocation(34, 9);
			Match('>'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__34", 25);
			LeaveRule("T__34", 25);
			LeaveRule_T__34();
		}
	}
	// $ANTLR end "T__34"

	partial void EnterRule_T__35();
	partial void LeaveRule_T__35();

	// $ANTLR start "T__35"
	[GrammarRule("T__35")]
	private void mT__35()
	{
		EnterRule_T__35();
		EnterRule("T__35", 26);
		TraceIn("T__35", 26);
		try
		{
			int _type = T__35;
			int _channel = DefaultTokenChannel;
			// udfs.g3:35:7: ( '>=' )
			DebugEnterAlt(1);
			// udfs.g3:35:9: '>='
			{
			DebugLocation(35, 9);
			Match(">="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__35", 26);
			LeaveRule("T__35", 26);
			LeaveRule_T__35();
		}
	}
	// $ANTLR end "T__35"

	partial void EnterRule_T__36();
	partial void LeaveRule_T__36();

	// $ANTLR start "T__36"
	[GrammarRule("T__36")]
	private void mT__36()
	{
		EnterRule_T__36();
		EnterRule("T__36", 27);
		TraceIn("T__36", 27);
		try
		{
			int _type = T__36;
			int _channel = DefaultTokenChannel;
			// udfs.g3:36:7: ( '^' )
			DebugEnterAlt(1);
			// udfs.g3:36:9: '^'
			{
			DebugLocation(36, 9);
			Match('^'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__36", 27);
			LeaveRule("T__36", 27);
			LeaveRule_T__36();
		}
	}
	// $ANTLR end "T__36"

	partial void EnterRule_T__37();
	partial void LeaveRule_T__37();

	// $ANTLR start "T__37"
	[GrammarRule("T__37")]
	private void mT__37()
	{
		EnterRule_T__37();
		EnterRule("T__37", 28);
		TraceIn("T__37", 28);
		try
		{
			int _type = T__37;
			int _channel = DefaultTokenChannel;
			// udfs.g3:37:7: ( '|' )
			DebugEnterAlt(1);
			// udfs.g3:37:9: '|'
			{
			DebugLocation(37, 9);
			Match('|'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__37", 28);
			LeaveRule("T__37", 28);
			LeaveRule_T__37();
		}
	}
	// $ANTLR end "T__37"

	partial void EnterRule_COMMENT();
	partial void LeaveRule_COMMENT();

	// $ANTLR start "COMMENT"
	[GrammarRule("COMMENT")]
	private void mCOMMENT()
	{
		EnterRule_COMMENT();
		EnterRule("COMMENT", 29);
		TraceIn("COMMENT", 29);
		try
		{
			int _type = COMMENT;
			int _channel = DefaultTokenChannel;
			// udfs.g3:157:2: ( '!!' (~ ( '\\r' | '\\n' ) )* NLINE )
			DebugEnterAlt(1);
			// udfs.g3:157:4: '!!' (~ ( '\\r' | '\\n' ) )* NLINE
			{
			DebugLocation(157, 4);
			Match("!!"); 

			DebugLocation(158, 3);
			// udfs.g3:158:3: (~ ( '\\r' | '\\n' ) )*
			try { DebugEnterSubRule(1);
			while (true)
			{
				int alt1=2;
				try { DebugEnterDecision(1, false);
				int LA1_1 = input.LA(1);

				if (((LA1_1>='\u0000' && LA1_1<='\t')||(LA1_1>='\u000B' && LA1_1<='\f')||(LA1_1>='\u000E' && LA1_1<='\uFFFF')))
				{
					alt1 = 1;
				}


				} finally { DebugExitDecision(1); }
				switch ( alt1 )
				{
				case 1:
					DebugEnterAlt(1);
					// udfs.g3:
					{
					DebugLocation(158, 3);
					input.Consume();


					}
					break;

				default:
					goto loop1;
				}
			}

			loop1:
				;

			} finally { DebugExitSubRule(1); }

			DebugLocation(159, 3);
			mNLINE(); 
			DebugLocation(160, 3);
			_channel=Hidden;

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("COMMENT", 29);
			LeaveRule("COMMENT", 29);
			LeaveRule_COMMENT();
		}
	}
	// $ANTLR end "COMMENT"

	partial void EnterRule_WS();
	partial void LeaveRule_WS();

	// $ANTLR start "WS"
	[GrammarRule("WS")]
	private void mWS()
	{
		EnterRule_WS();
		EnterRule("WS", 30);
		TraceIn("WS", 30);
		try
		{
			int _type = WS;
			int _channel = DefaultTokenChannel;
			// udfs.g3:164:5: ( ( ' ' | '\\t' ) )
			DebugEnterAlt(1);
			// udfs.g3:
			{
			DebugLocation(164, 5);
			if (input.LA(1)=='\t'||input.LA(1)==' ')
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
			TraceOut("WS", 30);
			LeaveRule("WS", 30);
			LeaveRule_WS();
		}
	}
	// $ANTLR end "WS"

	partial void EnterRule_NLINE();
	partial void LeaveRule_NLINE();

	// $ANTLR start "NLINE"
	[GrammarRule("NLINE")]
	private void mNLINE()
	{
		EnterRule_NLINE();
		EnterRule("NLINE", 31);
		TraceIn("NLINE", 31);
		try
		{
			int _type = NLINE;
			int _channel = DefaultTokenChannel;
			// udfs.g3:168:2: ( ( '\\r' )? '\\n' )
			DebugEnterAlt(1);
			// udfs.g3:168:4: ( '\\r' )? '\\n'
			{
			DebugLocation(168, 4);
			// udfs.g3:168:4: ( '\\r' )?
			int alt2=2;
			try { DebugEnterSubRule(2);
			try { DebugEnterDecision(2, false);
			int LA2_1 = input.LA(1);

			if ((LA2_1=='\r'))
			{
				alt2 = 1;
			}
			} finally { DebugExitDecision(2); }
			switch (alt2)
			{
			case 1:
				DebugEnterAlt(1);
				// udfs.g3:168:4: '\\r'
				{
				DebugLocation(168, 4);
				Match('\r'); 

				}
				break;

			}
			} finally { DebugExitSubRule(2); }

			DebugLocation(168, 10);
			Match('\n'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NLINE", 31);
			LeaveRule("NLINE", 31);
			LeaveRule_NLINE();
		}
	}
	// $ANTLR end "NLINE"

	partial void EnterRule_NUMBER();
	partial void LeaveRule_NUMBER();

	// $ANTLR start "NUMBER"
	[GrammarRule("NUMBER")]
	private void mNUMBER()
	{
		EnterRule_NUMBER();
		EnterRule("NUMBER", 32);
		TraceIn("NUMBER", 32);
		try
		{
			int _type = NUMBER;
			int _channel = DefaultTokenChannel;
			// udfs.g3:171:7: ( ( '+' | '-' )? ( '0' .. '9' )+ ( '.' ( '0' .. '9' )+ )? ( ( 'e' | 'E' ) ( '+' | '-' )? ( '0' .. '9' )+ )? )
			DebugEnterAlt(1);
			// udfs.g3:172:2: ( '+' | '-' )? ( '0' .. '9' )+ ( '.' ( '0' .. '9' )+ )? ( ( 'e' | 'E' ) ( '+' | '-' )? ( '0' .. '9' )+ )?
			{
			DebugLocation(172, 2);
			// udfs.g3:172:2: ( '+' | '-' )?
			int alt3=2;
			try { DebugEnterSubRule(3);
			try { DebugEnterDecision(3, false);
			int LA3_1 = input.LA(1);

			if ((LA3_1=='+'||LA3_1=='-'))
			{
				alt3 = 1;
			}
			} finally { DebugExitDecision(3); }
			switch (alt3)
			{
			case 1:
				DebugEnterAlt(1);
				// udfs.g3:
				{
				DebugLocation(172, 2);
				input.Consume();


				}
				break;

			}
			} finally { DebugExitSubRule(3); }

			DebugLocation(173, 5);
			// udfs.g3:173:5: ( '0' .. '9' )+
			int cnt4=0;
			try { DebugEnterSubRule(4);
			while (true)
			{
				int alt4=2;
				try { DebugEnterDecision(4, false);
				int LA4_1 = input.LA(1);

				if (((LA4_1>='0' && LA4_1<='9')))
				{
					alt4 = 1;
				}


				} finally { DebugExitDecision(4); }
				switch (alt4)
				{
				case 1:
					DebugEnterAlt(1);
					// udfs.g3:
					{
					DebugLocation(173, 5);
					input.Consume();


					}
					break;

				default:
					if (cnt4 >= 1)
						goto loop4;

					EarlyExitException eee4 = new EarlyExitException( 4, input );
					DebugRecognitionException(eee4);
					throw eee4;
				}
				cnt4++;
			}
			loop4:
				;

			} finally { DebugExitSubRule(4); }

			DebugLocation(174, 2);
			// udfs.g3:174:2: ( '.' ( '0' .. '9' )+ )?
			int alt6=2;
			try { DebugEnterSubRule(6);
			try { DebugEnterDecision(6, false);
			int LA6_1 = input.LA(1);

			if ((LA6_1=='.'))
			{
				alt6 = 1;
			}
			} finally { DebugExitDecision(6); }
			switch (alt6)
			{
			case 1:
				DebugEnterAlt(1);
				// udfs.g3:174:3: '.' ( '0' .. '9' )+
				{
				DebugLocation(174, 3);
				Match('.'); 
				DebugLocation(174, 10);
				// udfs.g3:174:10: ( '0' .. '9' )+
				int cnt5=0;
				try { DebugEnterSubRule(5);
				while (true)
				{
					int alt5=2;
					try { DebugEnterDecision(5, false);
					int LA5_1 = input.LA(1);

					if (((LA5_1>='0' && LA5_1<='9')))
					{
						alt5 = 1;
					}


					} finally { DebugExitDecision(5); }
					switch (alt5)
					{
					case 1:
						DebugEnterAlt(1);
						// udfs.g3:
						{
						DebugLocation(174, 10);
						input.Consume();


						}
						break;

					default:
						if (cnt5 >= 1)
							goto loop5;

						EarlyExitException eee5 = new EarlyExitException( 5, input );
						DebugRecognitionException(eee5);
						throw eee5;
					}
					cnt5++;
				}
				loop5:
					;

				} finally { DebugExitSubRule(5); }


				}
				break;

			}
			} finally { DebugExitSubRule(6); }

			DebugLocation(175, 2);
			// udfs.g3:175:2: ( ( 'e' | 'E' ) ( '+' | '-' )? ( '0' .. '9' )+ )?
			int alt9=2;
			try { DebugEnterSubRule(9);
			try { DebugEnterDecision(9, false);
			int LA9_1 = input.LA(1);

			if ((LA9_1=='E'||LA9_1=='e'))
			{
				alt9 = 1;
			}
			} finally { DebugExitDecision(9); }
			switch (alt9)
			{
			case 1:
				DebugEnterAlt(1);
				// udfs.g3:175:3: ( 'e' | 'E' ) ( '+' | '-' )? ( '0' .. '9' )+
				{
				DebugLocation(175, 3);
				input.Consume();

				DebugLocation(175, 15);
				// udfs.g3:175:15: ( '+' | '-' )?
				int alt7=2;
				try { DebugEnterSubRule(7);
				try { DebugEnterDecision(7, false);
				int LA7_1 = input.LA(1);

				if ((LA7_1=='+'||LA7_1=='-'))
				{
					alt7 = 1;
				}
				} finally { DebugExitDecision(7); }
				switch (alt7)
				{
				case 1:
					DebugEnterAlt(1);
					// udfs.g3:
					{
					DebugLocation(175, 15);
					input.Consume();


					}
					break;

				}
				} finally { DebugExitSubRule(7); }

				DebugLocation(175, 30);
				// udfs.g3:175:30: ( '0' .. '9' )+
				int cnt8=0;
				try { DebugEnterSubRule(8);
				while (true)
				{
					int alt8=2;
					try { DebugEnterDecision(8, false);
					int LA8_1 = input.LA(1);

					if (((LA8_1>='0' && LA8_1<='9')))
					{
						alt8 = 1;
					}


					} finally { DebugExitDecision(8); }
					switch (alt8)
					{
					case 1:
						DebugEnterAlt(1);
						// udfs.g3:
						{
						DebugLocation(175, 30);
						input.Consume();


						}
						break;

					default:
						if (cnt8 >= 1)
							goto loop8;

						EarlyExitException eee8 = new EarlyExitException( 8, input );
						DebugRecognitionException(eee8);
						throw eee8;
					}
					cnt8++;
				}
				loop8:
					;

				} finally { DebugExitSubRule(8); }


				}
				break;

			}
			} finally { DebugExitSubRule(9); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NUMBER", 32);
			LeaveRule("NUMBER", 32);
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
		EnterRule("IDINTIFIER", 33);
		TraceIn("IDINTIFIER", 33);
		try
		{
			int _type = IDINTIFIER;
			int _channel = DefaultTokenChannel;
			// udfs.g3:179:2: ( ( 'a' .. 'z' | 'A' .. 'Z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )* )
			DebugEnterAlt(1);
			// udfs.g3:179:4: ( 'a' .. 'z' | 'A' .. 'Z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )*
			{
			DebugLocation(179, 4);
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

			DebugLocation(179, 26);
			// udfs.g3:179:26: ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )*
			try { DebugEnterSubRule(10);
			while (true)
			{
				int alt10=2;
				try { DebugEnterDecision(10, false);
				int LA10_1 = input.LA(1);

				if (((LA10_1>='0' && LA10_1<='9')||(LA10_1>='A' && LA10_1<='Z')||LA10_1=='_'||(LA10_1>='a' && LA10_1<='z')))
				{
					alt10 = 1;
				}


				} finally { DebugExitDecision(10); }
				switch ( alt10 )
				{
				case 1:
					DebugEnterAlt(1);
					// udfs.g3:
					{
					DebugLocation(179, 26);
					input.Consume();


					}
					break;

				default:
					goto loop10;
				}
			}

			loop10:
				;

			} finally { DebugExitSubRule(10); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("IDINTIFIER", 33);
			LeaveRule("IDINTIFIER", 33);
			LeaveRule_IDINTIFIER();
		}
	}
	// $ANTLR end "IDINTIFIER"

	public override void mTokens()
	{
		// udfs.g3:1:8: ( CONST | ELSE | FUNCTION_DECL | GLOBAL | IF | LBRCT | LPARN | RBRCT | RET | RPARN | VAR | WHILE | T__22 | T__23 | T__24 | T__25 | T__26 | T__27 | T__28 | T__29 | T__30 | T__31 | T__32 | T__33 | T__34 | T__35 | T__36 | T__37 | COMMENT | WS | NLINE | NUMBER | IDINTIFIER )
		int alt11=33;
		try { DebugEnterDecision(11, false);
		try
		{
			alt11 = dfa11.Predict(input);
		}
		catch (NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
			throw;
		}
		} finally { DebugExitDecision(11); }
		switch (alt11)
		{
		case 1:
			DebugEnterAlt(1);
			// udfs.g3:1:10: CONST
			{
			DebugLocation(1, 10);
			mCONST(); 

			}
			break;
		case 2:
			DebugEnterAlt(2);
			// udfs.g3:1:16: ELSE
			{
			DebugLocation(1, 16);
			mELSE(); 

			}
			break;
		case 3:
			DebugEnterAlt(3);
			// udfs.g3:1:21: FUNCTION_DECL
			{
			DebugLocation(1, 21);
			mFUNCTION_DECL(); 

			}
			break;
		case 4:
			DebugEnterAlt(4);
			// udfs.g3:1:35: GLOBAL
			{
			DebugLocation(1, 35);
			mGLOBAL(); 

			}
			break;
		case 5:
			DebugEnterAlt(5);
			// udfs.g3:1:42: IF
			{
			DebugLocation(1, 42);
			mIF(); 

			}
			break;
		case 6:
			DebugEnterAlt(6);
			// udfs.g3:1:45: LBRCT
			{
			DebugLocation(1, 45);
			mLBRCT(); 

			}
			break;
		case 7:
			DebugEnterAlt(7);
			// udfs.g3:1:51: LPARN
			{
			DebugLocation(1, 51);
			mLPARN(); 

			}
			break;
		case 8:
			DebugEnterAlt(8);
			// udfs.g3:1:57: RBRCT
			{
			DebugLocation(1, 57);
			mRBRCT(); 

			}
			break;
		case 9:
			DebugEnterAlt(9);
			// udfs.g3:1:63: RET
			{
			DebugLocation(1, 63);
			mRET(); 

			}
			break;
		case 10:
			DebugEnterAlt(10);
			// udfs.g3:1:67: RPARN
			{
			DebugLocation(1, 67);
			mRPARN(); 

			}
			break;
		case 11:
			DebugEnterAlt(11);
			// udfs.g3:1:73: VAR
			{
			DebugLocation(1, 73);
			mVAR(); 

			}
			break;
		case 12:
			DebugEnterAlt(12);
			// udfs.g3:1:77: WHILE
			{
			DebugLocation(1, 77);
			mWHILE(); 

			}
			break;
		case 13:
			DebugEnterAlt(13);
			// udfs.g3:1:83: T__22
			{
			DebugLocation(1, 83);
			mT__22(); 

			}
			break;
		case 14:
			DebugEnterAlt(14);
			// udfs.g3:1:89: T__23
			{
			DebugLocation(1, 89);
			mT__23(); 

			}
			break;
		case 15:
			DebugEnterAlt(15);
			// udfs.g3:1:95: T__24
			{
			DebugLocation(1, 95);
			mT__24(); 

			}
			break;
		case 16:
			DebugEnterAlt(16);
			// udfs.g3:1:101: T__25
			{
			DebugLocation(1, 101);
			mT__25(); 

			}
			break;
		case 17:
			DebugEnterAlt(17);
			// udfs.g3:1:107: T__26
			{
			DebugLocation(1, 107);
			mT__26(); 

			}
			break;
		case 18:
			DebugEnterAlt(18);
			// udfs.g3:1:113: T__27
			{
			DebugLocation(1, 113);
			mT__27(); 

			}
			break;
		case 19:
			DebugEnterAlt(19);
			// udfs.g3:1:119: T__28
			{
			DebugLocation(1, 119);
			mT__28(); 

			}
			break;
		case 20:
			DebugEnterAlt(20);
			// udfs.g3:1:125: T__29
			{
			DebugLocation(1, 125);
			mT__29(); 

			}
			break;
		case 21:
			DebugEnterAlt(21);
			// udfs.g3:1:131: T__30
			{
			DebugLocation(1, 131);
			mT__30(); 

			}
			break;
		case 22:
			DebugEnterAlt(22);
			// udfs.g3:1:137: T__31
			{
			DebugLocation(1, 137);
			mT__31(); 

			}
			break;
		case 23:
			DebugEnterAlt(23);
			// udfs.g3:1:143: T__32
			{
			DebugLocation(1, 143);
			mT__32(); 

			}
			break;
		case 24:
			DebugEnterAlt(24);
			// udfs.g3:1:149: T__33
			{
			DebugLocation(1, 149);
			mT__33(); 

			}
			break;
		case 25:
			DebugEnterAlt(25);
			// udfs.g3:1:155: T__34
			{
			DebugLocation(1, 155);
			mT__34(); 

			}
			break;
		case 26:
			DebugEnterAlt(26);
			// udfs.g3:1:161: T__35
			{
			DebugLocation(1, 161);
			mT__35(); 

			}
			break;
		case 27:
			DebugEnterAlt(27);
			// udfs.g3:1:167: T__36
			{
			DebugLocation(1, 167);
			mT__36(); 

			}
			break;
		case 28:
			DebugEnterAlt(28);
			// udfs.g3:1:173: T__37
			{
			DebugLocation(1, 173);
			mT__37(); 

			}
			break;
		case 29:
			DebugEnterAlt(29);
			// udfs.g3:1:179: COMMENT
			{
			DebugLocation(1, 179);
			mCOMMENT(); 

			}
			break;
		case 30:
			DebugEnterAlt(30);
			// udfs.g3:1:187: WS
			{
			DebugLocation(1, 187);
			mWS(); 

			}
			break;
		case 31:
			DebugEnterAlt(31);
			// udfs.g3:1:190: NLINE
			{
			DebugLocation(1, 190);
			mNLINE(); 

			}
			break;
		case 32:
			DebugEnterAlt(32);
			// udfs.g3:1:196: NUMBER
			{
			DebugLocation(1, 196);
			mNUMBER(); 

			}
			break;
		case 33:
			DebugEnterAlt(33);
			// udfs.g3:1:203: IDINTIFIER
			{
			DebugLocation(1, 203);
			mIDINTIFIER(); 

			}
			break;

		}

	}


	#region DFA
	DFA11 dfa11;

	protected override void InitDFAs()
	{
		base.InitDFAs();
		dfa11 = new DFA11(this);
	}

	private class DFA11 : DFA
	{
		private const string DFA11_eotS =
			"\x1\xFFFF\x5\x1E\x3\xFFFF\x1\x1E\x1\xFFFF\x2\x1E\x4\xFFFF\x1\x29\x1\xFFFF"+
			"\x1\x2A\x2\xFFFF\x1\x2C\x1\xFFFF\x1\x2E\x6\xFFFF\x4\x1E\x1\x33\x3\x1E"+
			"\x8\xFFFF\x4\x1E\x1\xFFFF\x4\x1E\x1\x3F\x5\x1E\x1\x45\x1\xFFFF\x4\x1E"+
			"\x1\x4A\x1\xFFFF\x1\x1E\x1\x4C\x2\x1E\x1\xFFFF\x1\x1E\x1\xFFFF\x1\x1E"+
			"\x1\x51\x1\x52\x1\x53\x3\xFFFF";
		private const string DFA11_eofS =
			"\x54\xFFFF";
		private const string DFA11_minS =
			"\x1\x9\x1\x6F\x1\x6C\x1\x75\x1\x6C\x1\x66\x3\xFFFF\x1\x65\x1\xFFFF\x1"+
			"\x65\x1\x68\x1\x21\x3\xFFFF\x1\x30\x1\xFFFF\x1\x30\x2\xFFFF\x1\x3D\x1"+
			"\xFFFF\x1\x3D\x6\xFFFF\x1\x6E\x1\x73\x1\x6E\x1\x6F\x1\x30\x1\x73\x1\x63"+
			"\x1\x69\x8\xFFFF\x1\x73\x1\x65\x1\x63\x1\x62\x1\xFFFF\x1\x75\x2\x6C\x1"+
			"\x74\x1\x30\x1\x74\x1\x61\x1\x6C\x1\x76\x1\x65\x1\x30\x1\xFFFF\x1\x69"+
			"\x1\x6C\x1\x74\x1\x61\x1\x30\x1\xFFFF\x1\x6F\x1\x30\x1\x69\x1\x72\x1"+
			"\xFFFF\x1\x6E\x1\xFFFF\x1\x73\x3\x30\x3\xFFFF";
		private const string DFA11_maxS =
			"\x1\x7D\x1\x6F\x1\x6C\x1\x75\x1\x6C\x1\x66\x3\xFFFF\x1\x65\x1\xFFFF\x1"+
			"\x65\x1\x68\x1\x3D\x3\xFFFF\x1\x39\x1\xFFFF\x1\x39\x2\xFFFF\x1\x3D\x1"+
			"\xFFFF\x1\x3D\x6\xFFFF\x1\x6E\x1\x73\x1\x6E\x1\x6F\x1\x7A\x1\x73\x1\x63"+
			"\x1\x69\x8\xFFFF\x1\x73\x1\x65\x1\x63\x1\x62\x1\xFFFF\x1\x75\x2\x6C\x1"+
			"\x74\x1\x7A\x1\x74\x1\x61\x1\x6C\x1\x76\x1\x65\x1\x7A\x1\xFFFF\x1\x69"+
			"\x1\x6C\x1\x74\x1\x61\x1\x7A\x1\xFFFF\x1\x6F\x1\x7A\x1\x69\x1\x72\x1"+
			"\xFFFF\x1\x6E\x1\xFFFF\x1\x73\x3\x7A\x3\xFFFF";
		private const string DFA11_acceptS =
			"\x6\xFFFF\x1\x6\x1\x7\x1\x8\x1\xFFFF\x1\xA\x3\xFFFF\x1\xE\x1\xF\x1\x10"+
			"\x1\xFFFF\x1\x12\x1\xFFFF\x1\x14\x1\x15\x1\xFFFF\x1\x18\x1\xFFFF\x1\x1B"+
			"\x1\x1C\x1\x1E\x1\x1F\x1\x20\x1\x21\x8\xFFFF\x1\xD\x1\x1D\x1\x11\x1\x13"+
			"\x1\x17\x1\x16\x1\x1A\x1\x19\x4\xFFFF\x1\x5\xB\xFFFF\x1\x2\x5\xFFFF\x1"+
			"\x1\x4\xFFFF\x1\xC\x1\xFFFF\x1\x4\x4\xFFFF\x1\xB\x1\x3\x1\x9";
		private const string DFA11_specialS =
			"\x54\xFFFF}>";
		private static readonly string[] DFA11_transitionS =
			{
				"\x1\x1B\x1\x1C\x2\xFFFF\x1\x1C\x12\xFFFF\x1\x1B\x1\xD\x3\xFFFF\x1\xE"+
				"\x1\xF\x1\xFFFF\x1\x7\x1\xA\x1\x10\x1\x11\x1\x12\x1\x13\x1\xFFFF\x1"+
				"\x14\xA\x1D\x1\x15\x1\xFFFF\x1\x16\x1\x17\x1\x18\x2\xFFFF\x1A\x1E\x3"+
				"\xFFFF\x1\x19\x2\xFFFF\x2\x1E\x1\x1\x1\xB\x1\x2\x1\x3\x1\x4\x1\x1E\x1"+
				"\x5\x8\x1E\x1\x9\x4\x1E\x1\xC\x3\x1E\x1\x6\x1\x1A\x1\x8",
				"\x1\x1F",
				"\x1\x20",
				"\x1\x21",
				"\x1\x22",
				"\x1\x23",
				"",
				"",
				"",
				"\x1\x24",
				"",
				"\x1\x25",
				"\x1\x26",
				"\x1\x28\x1B\xFFFF\x1\x27",
				"",
				"",
				"",
				"\xA\x1D",
				"",
				"\xA\x1D",
				"",
				"",
				"\x1\x2B",
				"",
				"\x1\x2D",
				"",
				"",
				"",
				"",
				"",
				"",
				"\x1\x2F",
				"\x1\x30",
				"\x1\x31",
				"\x1\x32",
				"\xA\x1E\x7\xFFFF\x1A\x1E\x4\xFFFF\x1\x1E\x1\xFFFF\x1A\x1E",
				"\x1\x34",
				"\x1\x35",
				"\x1\x36",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"\x1\x37",
				"\x1\x38",
				"\x1\x39",
				"\x1\x3A",
				"",
				"\x1\x3B",
				"\x1\x3C",
				"\x1\x3D",
				"\x1\x3E",
				"\xA\x1E\x7\xFFFF\x1A\x1E\x4\xFFFF\x1\x1E\x1\xFFFF\x1A\x1E",
				"\x1\x40",
				"\x1\x41",
				"\x1\x42",
				"\x1\x43",
				"\x1\x44",
				"\xA\x1E\x7\xFFFF\x1A\x1E\x4\xFFFF\x1\x1E\x1\xFFFF\x1A\x1E",
				"",
				"\x1\x46",
				"\x1\x47",
				"\x1\x48",
				"\x1\x49",
				"\xA\x1E\x7\xFFFF\x1A\x1E\x4\xFFFF\x1\x1E\x1\xFFFF\x1A\x1E",
				"",
				"\x1\x4B",
				"\xA\x1E\x7\xFFFF\x1A\x1E\x4\xFFFF\x1\x1E\x1\xFFFF\x1A\x1E",
				"\x1\x4D",
				"\x1\x4E",
				"",
				"\x1\x4F",
				"",
				"\x1\x50",
				"\xA\x1E\x7\xFFFF\x1A\x1E\x4\xFFFF\x1\x1E\x1\xFFFF\x1A\x1E",
				"\xA\x1E\x7\xFFFF\x1A\x1E\x4\xFFFF\x1\x1E\x1\xFFFF\x1A\x1E",
				"\xA\x1E\x7\xFFFF\x1A\x1E\x4\xFFFF\x1\x1E\x1\xFFFF\x1A\x1E",
				"",
				"",
				""
			};

		private static readonly short[] DFA11_eot = DFA.UnpackEncodedString(DFA11_eotS);
		private static readonly short[] DFA11_eof = DFA.UnpackEncodedString(DFA11_eofS);
		private static readonly char[] DFA11_min = DFA.UnpackEncodedStringToUnsignedChars(DFA11_minS);
		private static readonly char[] DFA11_max = DFA.UnpackEncodedStringToUnsignedChars(DFA11_maxS);
		private static readonly short[] DFA11_accept = DFA.UnpackEncodedString(DFA11_acceptS);
		private static readonly short[] DFA11_special = DFA.UnpackEncodedString(DFA11_specialS);
		private static readonly short[][] DFA11_transition;

		static DFA11()
		{
			int numStates = DFA11_transitionS.Length;
			DFA11_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA11_transition[i] = DFA.UnpackEncodedString(DFA11_transitionS[i]);
			}
		}

		public DFA11( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 11;
			this.eot = DFA11_eot;
			this.eof = DFA11_eof;
			this.min = DFA11_min;
			this.max = DFA11_max;
			this.accept = DFA11_accept;
			this.special = DFA11_special;
			this.transition = DFA11_transition;
		}

		public override string Description { get { return "1:1: Tokens : ( CONST | ELSE | FUNCTION_DECL | GLOBAL | IF | LBRCT | LPARN | RBRCT | RET | RPARN | VAR | WHILE | T__22 | T__23 | T__24 | T__25 | T__26 | T__27 | T__28 | T__29 | T__30 | T__31 | T__32 | T__33 | T__34 | T__35 | T__36 | T__37 | COMMENT | WS | NLINE | NUMBER | IDINTIFIER );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}


	#endregion

}

} // namespace Sketcher.Udfs.Lexer
