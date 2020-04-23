// Generated from f:\Src\httpParser\src\Black.Beard.Sdk.HttpParser\Grammar\Generator\HtmlPatternParser.g4 by ANTLR 4.7.1
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class HtmlPatternParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.7.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		AS=1, ATTRIBUTE=2, ARRAY=3, SUB=4, SKIP1=5, JSON=6, NODE=7, NEW=8, OBJECT=9, 
		PROPERTY=10, SEARCH=11, SELECT=12, LIMIT=13, USING=14, HTML=15, TEXT=16, 
		STRING=17, DECIMAL=18, INTEGER=19, DATE=20, UUID=21, BOOLEAN=22, TRUE=23, 
		FALSE=24, CHAR_STRING=25, DOLLAR=26, LEFT_PAREN=27, RIGHT_PAREN=28, LEFT_BRACE=29, 
		RIGHT_BRACE=30, SEMICOLON=31, COLON=32, COMMA=33, DOT=34, WILDCARD=35, 
		PIPE=36, SPACES=37, NUMBER=38, SINGLE_LINE_COMMENT=39, MULTI_LINE_COMMENT=40, 
		REGULAR_ID=41;
	public static final int
		RULE_script = 0, RULE_unit_statement = 1, RULE_using = 2, RULE_search = 3, 
		RULE_output = 4, RULE_select = 5, RULE_selectItem = 6, RULE_type = 7, 
		RULE_attribute = 8, RULE_pagination = 9, RULE_count = 10, RULE_function = 11, 
		RULE_arguments = 12, RULE_argument = 13, RULE_key = 14, RULE_numbers = 15, 
		RULE_float = 16, RULE_text = 17, RULE_boolean = 18, RULE_variable = 19;
	public static final String[] ruleNames = {
		"script", "unit_statement", "using", "search", "output", "select", "selectItem", 
		"type", "attribute", "pagination", "count", "function", "arguments", "argument", 
		"key", "numbers", "float", "text", "boolean", "variable"
	};

	private static final String[] _LITERAL_NAMES = {
		null, "'AS'", "'ATTRIBUTE'", "'ARRAY'", "'SUB'", "'SKIP'", "'JSON'", "'NODE'", 
		"'NEW'", "'OBJECT'", "'PROPERTY'", "'SEARCH'", "'SELECT'", "'LIMIT'", 
		"'USING'", "'HTML'", "'TEXT'", "'STRING'", "'DECIMAL'", "'INTEGER'", "'DATE'", 
		"'UUID'", "'BOOLEAN'", "'true'", "'false'", null, "'$'", "'('", "')'", 
		"'{'", "'}'", "';'", "':'", "','", "'.'", "'*'", "'|'"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, "AS", "ATTRIBUTE", "ARRAY", "SUB", "SKIP1", "JSON", "NODE", "NEW", 
		"OBJECT", "PROPERTY", "SEARCH", "SELECT", "LIMIT", "USING", "HTML", "TEXT", 
		"STRING", "DECIMAL", "INTEGER", "DATE", "UUID", "BOOLEAN", "TRUE", "FALSE", 
		"CHAR_STRING", "DOLLAR", "LEFT_PAREN", "RIGHT_PAREN", "LEFT_BRACE", "RIGHT_BRACE", 
		"SEMICOLON", "COLON", "COMMA", "DOT", "WILDCARD", "PIPE", "SPACES", "NUMBER", 
		"SINGLE_LINE_COMMENT", "MULTI_LINE_COMMENT", "REGULAR_ID"
	};
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "HtmlPatternParser.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public HtmlPatternParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}
	public static class ScriptContext extends ParserRuleContext {
		public TerminalNode EOF() { return getToken(HtmlPatternParser.EOF, 0); }
		public List<UsingContext> using() {
			return getRuleContexts(UsingContext.class);
		}
		public UsingContext using(int i) {
			return getRuleContext(UsingContext.class,i);
		}
		public List<Unit_statementContext> unit_statement() {
			return getRuleContexts(Unit_statementContext.class);
		}
		public Unit_statementContext unit_statement(int i) {
			return getRuleContext(Unit_statementContext.class,i);
		}
		public List<TerminalNode> SEMICOLON() { return getTokens(HtmlPatternParser.SEMICOLON); }
		public TerminalNode SEMICOLON(int i) {
			return getToken(HtmlPatternParser.SEMICOLON, i);
		}
		public ScriptContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_script; }
	}

	public final ScriptContext script() throws RecognitionException {
		ScriptContext _localctx = new ScriptContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_script);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(43);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==USING) {
				{
				{
				setState(40);
				using();
				}
				}
				setState(45);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(51);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==SEARCH) {
				{
				{
				setState(46);
				unit_statement();
				setState(47);
				match(SEMICOLON);
				}
				}
				setState(53);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(54);
			match(EOF);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Unit_statementContext extends ParserRuleContext {
		public SearchContext search() {
			return getRuleContext(SearchContext.class,0);
		}
		public Unit_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_unit_statement; }
	}

	public final Unit_statementContext unit_statement() throws RecognitionException {
		Unit_statementContext _localctx = new Unit_statementContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_unit_statement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(56);
			search();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class UsingContext extends ParserRuleContext {
		public TerminalNode USING() { return getToken(HtmlPatternParser.USING, 0); }
		public TextContext text() {
			return getRuleContext(TextContext.class,0);
		}
		public UsingContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_using; }
	}

	public final UsingContext using() throws RecognitionException {
		UsingContext _localctx = new UsingContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_using);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(58);
			match(USING);
			setState(59);
			text();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class SearchContext extends ParserRuleContext {
		public TerminalNode SEARCH() { return getToken(HtmlPatternParser.SEARCH, 0); }
		public TerminalNode NODE() { return getToken(HtmlPatternParser.NODE, 0); }
		public List<TextContext> text() {
			return getRuleContexts(TextContext.class);
		}
		public TextContext text(int i) {
			return getRuleContext(TextContext.class,i);
		}
		public PaginationContext pagination() {
			return getRuleContext(PaginationContext.class,0);
		}
		public TerminalNode LEFT_PAREN() { return getToken(HtmlPatternParser.LEFT_PAREN, 0); }
		public TerminalNode RIGHT_PAREN() { return getToken(HtmlPatternParser.RIGHT_PAREN, 0); }
		public TerminalNode SUB() { return getToken(HtmlPatternParser.SUB, 0); }
		public NumbersContext numbers() {
			return getRuleContext(NumbersContext.class,0);
		}
		public List<TerminalNode> PIPE() { return getTokens(HtmlPatternParser.PIPE); }
		public TerminalNode PIPE(int i) {
			return getToken(HtmlPatternParser.PIPE, i);
		}
		public OutputContext output() {
			return getRuleContext(OutputContext.class,0);
		}
		public List<SearchContext> search() {
			return getRuleContexts(SearchContext.class);
		}
		public SearchContext search(int i) {
			return getRuleContext(SearchContext.class,i);
		}
		public List<SelectContext> select() {
			return getRuleContexts(SelectContext.class);
		}
		public SelectContext select(int i) {
			return getRuleContext(SelectContext.class,i);
		}
		public SearchContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_search; }
	}

	public final SearchContext search() throws RecognitionException {
		SearchContext _localctx = new SearchContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_search);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(61);
			match(SEARCH);
			setState(64);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==SUB) {
				{
				setState(62);
				match(SUB);
				setState(63);
				numbers();
				}
			}

			setState(66);
			match(NODE);
			setState(67);
			text();
			setState(72);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==PIPE) {
				{
				{
				setState(68);
				match(PIPE);
				setState(69);
				text();
				}
				}
				setState(74);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(75);
			pagination();
			setState(77);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==AS) {
				{
				setState(76);
				output();
				}
			}

			setState(79);
			match(LEFT_PAREN);
			setState(84);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << SEARCH) | (1L << CHAR_STRING) | (1L << DOLLAR))) != 0)) {
				{
				setState(82);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case SEARCH:
					{
					setState(80);
					search();
					}
					break;
				case CHAR_STRING:
				case DOLLAR:
					{
					setState(81);
					select();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(86);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(87);
			match(RIGHT_PAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class OutputContext extends ParserRuleContext {
		public TerminalNode AS() { return getToken(HtmlPatternParser.AS, 0); }
		public TerminalNode NEW() { return getToken(HtmlPatternParser.NEW, 0); }
		public TerminalNode OBJECT() { return getToken(HtmlPatternParser.OBJECT, 0); }
		public TerminalNode ARRAY() { return getToken(HtmlPatternParser.ARRAY, 0); }
		public TerminalNode PROPERTY() { return getToken(HtmlPatternParser.PROPERTY, 0); }
		public TextContext text() {
			return getRuleContext(TextContext.class,0);
		}
		public TerminalNode COLON() { return getToken(HtmlPatternParser.COLON, 0); }
		public OutputContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_output; }
	}

	public final OutputContext output() throws RecognitionException {
		OutputContext _localctx = new OutputContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_output);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(89);
			match(AS);
			setState(90);
			match(NEW);
			setState(97);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case OBJECT:
				{
				setState(91);
				match(OBJECT);
				}
				break;
			case ARRAY:
				{
				setState(92);
				match(ARRAY);
				}
				break;
			case PROPERTY:
				{
				setState(93);
				match(PROPERTY);
				setState(94);
				text();
				setState(95);
				match(COLON);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class SelectContext extends ParserRuleContext {
		public TerminalNode COLON() { return getToken(HtmlPatternParser.COLON, 0); }
		public SelectItemContext selectItem() {
			return getRuleContext(SelectItemContext.class,0);
		}
		public TextContext text() {
			return getRuleContext(TextContext.class,0);
		}
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public TerminalNode AS() { return getToken(HtmlPatternParser.AS, 0); }
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public List<TerminalNode> LEFT_PAREN() { return getTokens(HtmlPatternParser.LEFT_PAREN); }
		public TerminalNode LEFT_PAREN(int i) {
			return getToken(HtmlPatternParser.LEFT_PAREN, i);
		}
		public List<SearchContext> search() {
			return getRuleContexts(SearchContext.class);
		}
		public SearchContext search(int i) {
			return getRuleContext(SearchContext.class,i);
		}
		public List<TerminalNode> RIGHT_PAREN() { return getTokens(HtmlPatternParser.RIGHT_PAREN); }
		public TerminalNode RIGHT_PAREN(int i) {
			return getToken(HtmlPatternParser.RIGHT_PAREN, i);
		}
		public SelectContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_select; }
	}

	public final SelectContext select() throws RecognitionException {
		SelectContext _localctx = new SelectContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_select);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(101);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case CHAR_STRING:
				{
				setState(99);
				text();
				}
				break;
			case DOLLAR:
				{
				setState(100);
				variable();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(103);
			match(COLON);
			setState(106);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==AS) {
				{
				setState(104);
				match(AS);
				setState(105);
				type();
				}
			}

			setState(108);
			selectItem();
			setState(115);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==LEFT_PAREN) {
				{
				{
				setState(109);
				match(LEFT_PAREN);
				setState(110);
				search();
				setState(111);
				match(RIGHT_PAREN);
				}
				}
				setState(117);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class SelectItemContext extends ParserRuleContext {
		public TerminalNode SELECT() { return getToken(HtmlPatternParser.SELECT, 0); }
		public AttributeContext attribute() {
			return getRuleContext(AttributeContext.class,0);
		}
		public TerminalNode HTML() { return getToken(HtmlPatternParser.HTML, 0); }
		public TerminalNode TEXT() { return getToken(HtmlPatternParser.TEXT, 0); }
		public TextContext text() {
			return getRuleContext(TextContext.class,0);
		}
		public NumbersContext numbers() {
			return getRuleContext(NumbersContext.class,0);
		}
		public FloatContext float() {
			return getRuleContext(FloatContext.class,0);
		}
		public BooleanContext boolean() {
			return getRuleContext(BooleanContext.class,0);
		}
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public FunctionContext function() {
			return getRuleContext(FunctionContext.class,0);
		}
		public SelectItemContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_selectItem; }
	}

	public final SelectItemContext selectItem() throws RecognitionException {
		SelectItemContext _localctx = new SelectItemContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_selectItem);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(118);
			match(SELECT);
			setState(127);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,11,_ctx) ) {
			case 1:
				{
				setState(119);
				attribute();
				}
				break;
			case 2:
				{
				setState(120);
				match(HTML);
				}
				break;
			case 3:
				{
				setState(121);
				match(TEXT);
				}
				break;
			case 4:
				{
				setState(122);
				text();
				}
				break;
			case 5:
				{
				setState(123);
				numbers();
				}
				break;
			case 6:
				{
				setState(124);
				float();
				}
				break;
			case 7:
				{
				setState(125);
				boolean();
				}
				break;
			case 8:
				{
				setState(126);
				variable();
				}
				break;
			}
			setState(130);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==REGULAR_ID) {
				{
				setState(129);
				function();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class TypeContext extends ParserRuleContext {
		public TerminalNode STRING() { return getToken(HtmlPatternParser.STRING, 0); }
		public TerminalNode DECIMAL() { return getToken(HtmlPatternParser.DECIMAL, 0); }
		public TerminalNode INTEGER() { return getToken(HtmlPatternParser.INTEGER, 0); }
		public TerminalNode DATE() { return getToken(HtmlPatternParser.DATE, 0); }
		public TerminalNode UUID() { return getToken(HtmlPatternParser.UUID, 0); }
		public TerminalNode BOOLEAN() { return getToken(HtmlPatternParser.BOOLEAN, 0); }
		public TypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_type; }
	}

	public final TypeContext type() throws RecognitionException {
		TypeContext _localctx = new TypeContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_type);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(132);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << STRING) | (1L << DECIMAL) | (1L << INTEGER) | (1L << DATE) | (1L << UUID) | (1L << BOOLEAN))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AttributeContext extends ParserRuleContext {
		public TerminalNode ATTRIBUTE() { return getToken(HtmlPatternParser.ATTRIBUTE, 0); }
		public TextContext text() {
			return getRuleContext(TextContext.class,0);
		}
		public AttributeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_attribute; }
	}

	public final AttributeContext attribute() throws RecognitionException {
		AttributeContext _localctx = new AttributeContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_attribute);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(134);
			match(ATTRIBUTE);
			setState(135);
			text();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PaginationContext extends ParserRuleContext {
		public CountContext c1;
		public CountContext c2;
		public TerminalNode SKIP1() { return getToken(HtmlPatternParser.SKIP1, 0); }
		public TerminalNode LIMIT() { return getToken(HtmlPatternParser.LIMIT, 0); }
		public List<CountContext> count() {
			return getRuleContexts(CountContext.class);
		}
		public CountContext count(int i) {
			return getRuleContext(CountContext.class,i);
		}
		public PaginationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_pagination; }
	}

	public final PaginationContext pagination() throws RecognitionException {
		PaginationContext _localctx = new PaginationContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_pagination);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(139);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==SKIP1) {
				{
				setState(137);
				match(SKIP1);
				setState(138);
				((PaginationContext)_localctx).c1 = count();
				}
			}

			setState(143);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==LIMIT) {
				{
				setState(141);
				match(LIMIT);
				setState(142);
				((PaginationContext)_localctx).c2 = count();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CountContext extends ParserRuleContext {
		public NumbersContext numbers() {
			return getRuleContext(NumbersContext.class,0);
		}
		public TerminalNode WILDCARD() { return getToken(HtmlPatternParser.WILDCARD, 0); }
		public CountContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_count; }
	}

	public final CountContext count() throws RecognitionException {
		CountContext _localctx = new CountContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_count);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(147);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NUMBER:
				{
				setState(145);
				numbers();
				}
				break;
			case WILDCARD:
				{
				setState(146);
				match(WILDCARD);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionContext extends ParserRuleContext {
		public KeyContext key() {
			return getRuleContext(KeyContext.class,0);
		}
		public TerminalNode LEFT_PAREN() { return getToken(HtmlPatternParser.LEFT_PAREN, 0); }
		public TerminalNode RIGHT_PAREN() { return getToken(HtmlPatternParser.RIGHT_PAREN, 0); }
		public ArgumentsContext arguments() {
			return getRuleContext(ArgumentsContext.class,0);
		}
		public TerminalNode PIPE() { return getToken(HtmlPatternParser.PIPE, 0); }
		public FunctionContext function() {
			return getRuleContext(FunctionContext.class,0);
		}
		public FunctionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_function; }
	}

	public final FunctionContext function() throws RecognitionException {
		FunctionContext _localctx = new FunctionContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_function);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(149);
			key();
			setState(150);
			match(LEFT_PAREN);
			setState(152);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==CHAR_STRING || _la==NUMBER) {
				{
				setState(151);
				arguments();
				}
			}

			setState(154);
			match(RIGHT_PAREN);
			setState(157);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==PIPE) {
				{
				setState(155);
				match(PIPE);
				setState(156);
				function();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ArgumentsContext extends ParserRuleContext {
		public List<ArgumentContext> argument() {
			return getRuleContexts(ArgumentContext.class);
		}
		public ArgumentContext argument(int i) {
			return getRuleContext(ArgumentContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(HtmlPatternParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(HtmlPatternParser.COMMA, i);
		}
		public ArgumentsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_arguments; }
	}

	public final ArgumentsContext arguments() throws RecognitionException {
		ArgumentsContext _localctx = new ArgumentsContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_arguments);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(159);
			argument();
			setState(164);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(160);
				match(COMMA);
				setState(161);
				argument();
				}
				}
				setState(166);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ArgumentContext extends ParserRuleContext {
		public NumbersContext numbers() {
			return getRuleContext(NumbersContext.class,0);
		}
		public TextContext text() {
			return getRuleContext(TextContext.class,0);
		}
		public ArgumentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_argument; }
	}

	public final ArgumentContext argument() throws RecognitionException {
		ArgumentContext _localctx = new ArgumentContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_argument);
		try {
			setState(169);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NUMBER:
				enterOuterAlt(_localctx, 1);
				{
				setState(167);
				numbers();
				}
				break;
			case CHAR_STRING:
				enterOuterAlt(_localctx, 2);
				{
				setState(168);
				text();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class KeyContext extends ParserRuleContext {
		public TerminalNode REGULAR_ID() { return getToken(HtmlPatternParser.REGULAR_ID, 0); }
		public KeyContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_key; }
	}

	public final KeyContext key() throws RecognitionException {
		KeyContext _localctx = new KeyContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_key);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(171);
			match(REGULAR_ID);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NumbersContext extends ParserRuleContext {
		public List<TerminalNode> NUMBER() { return getTokens(HtmlPatternParser.NUMBER); }
		public TerminalNode NUMBER(int i) {
			return getToken(HtmlPatternParser.NUMBER, i);
		}
		public NumbersContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_numbers; }
	}

	public final NumbersContext numbers() throws RecognitionException {
		NumbersContext _localctx = new NumbersContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_numbers);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(174); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(173);
				match(NUMBER);
				}
				}
				setState(176); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==NUMBER );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FloatContext extends ParserRuleContext {
		public List<NumbersContext> numbers() {
			return getRuleContexts(NumbersContext.class);
		}
		public NumbersContext numbers(int i) {
			return getRuleContext(NumbersContext.class,i);
		}
		public TerminalNode DOT() { return getToken(HtmlPatternParser.DOT, 0); }
		public FloatContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_float; }
	}

	public final FloatContext float() throws RecognitionException {
		FloatContext _localctx = new FloatContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_float);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(178);
			numbers();
			setState(179);
			match(DOT);
			setState(180);
			numbers();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class TextContext extends ParserRuleContext {
		public TerminalNode CHAR_STRING() { return getToken(HtmlPatternParser.CHAR_STRING, 0); }
		public TextContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_text; }
	}

	public final TextContext text() throws RecognitionException {
		TextContext _localctx = new TextContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_text);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(182);
			match(CHAR_STRING);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class BooleanContext extends ParserRuleContext {
		public TerminalNode TRUE() { return getToken(HtmlPatternParser.TRUE, 0); }
		public TerminalNode FALSE() { return getToken(HtmlPatternParser.FALSE, 0); }
		public BooleanContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_boolean; }
	}

	public final BooleanContext boolean() throws RecognitionException {
		BooleanContext _localctx = new BooleanContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_boolean);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(184);
			_la = _input.LA(1);
			if ( !(_la==TRUE || _la==FALSE) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class VariableContext extends ParserRuleContext {
		public TerminalNode DOLLAR() { return getToken(HtmlPatternParser.DOLLAR, 0); }
		public KeyContext key() {
			return getRuleContext(KeyContext.class,0);
		}
		public VariableContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_variable; }
	}

	public final VariableContext variable() throws RecognitionException {
		VariableContext _localctx = new VariableContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_variable);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(186);
			match(DOLLAR);
			setState(187);
			key();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3+\u00c0\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\3\2\7\2,\n\2\f\2\16\2/\13\2\3\2\3\2\3\2"+
		"\7\2\64\n\2\f\2\16\2\67\13\2\3\2\3\2\3\3\3\3\3\4\3\4\3\4\3\5\3\5\3\5\5"+
		"\5C\n\5\3\5\3\5\3\5\3\5\7\5I\n\5\f\5\16\5L\13\5\3\5\3\5\5\5P\n\5\3\5\3"+
		"\5\3\5\7\5U\n\5\f\5\16\5X\13\5\3\5\3\5\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6"+
		"\5\6d\n\6\3\7\3\7\5\7h\n\7\3\7\3\7\3\7\5\7m\n\7\3\7\3\7\3\7\3\7\3\7\7"+
		"\7t\n\7\f\7\16\7w\13\7\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\5\b\u0082\n"+
		"\b\3\b\5\b\u0085\n\b\3\t\3\t\3\n\3\n\3\n\3\13\3\13\5\13\u008e\n\13\3\13"+
		"\3\13\5\13\u0092\n\13\3\f\3\f\5\f\u0096\n\f\3\r\3\r\3\r\5\r\u009b\n\r"+
		"\3\r\3\r\3\r\5\r\u00a0\n\r\3\16\3\16\3\16\7\16\u00a5\n\16\f\16\16\16\u00a8"+
		"\13\16\3\17\3\17\5\17\u00ac\n\17\3\20\3\20\3\21\6\21\u00b1\n\21\r\21\16"+
		"\21\u00b2\3\22\3\22\3\22\3\22\3\23\3\23\3\24\3\24\3\25\3\25\3\25\3\25"+
		"\2\2\26\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&(\2\4\3\2\23\30\3\2"+
		"\31\32\2\u00c7\2-\3\2\2\2\4:\3\2\2\2\6<\3\2\2\2\b?\3\2\2\2\n[\3\2\2\2"+
		"\fg\3\2\2\2\16x\3\2\2\2\20\u0086\3\2\2\2\22\u0088\3\2\2\2\24\u008d\3\2"+
		"\2\2\26\u0095\3\2\2\2\30\u0097\3\2\2\2\32\u00a1\3\2\2\2\34\u00ab\3\2\2"+
		"\2\36\u00ad\3\2\2\2 \u00b0\3\2\2\2\"\u00b4\3\2\2\2$\u00b8\3\2\2\2&\u00ba"+
		"\3\2\2\2(\u00bc\3\2\2\2*,\5\6\4\2+*\3\2\2\2,/\3\2\2\2-+\3\2\2\2-.\3\2"+
		"\2\2.\65\3\2\2\2/-\3\2\2\2\60\61\5\4\3\2\61\62\7!\2\2\62\64\3\2\2\2\63"+
		"\60\3\2\2\2\64\67\3\2\2\2\65\63\3\2\2\2\65\66\3\2\2\2\668\3\2\2\2\67\65"+
		"\3\2\2\289\7\2\2\39\3\3\2\2\2:;\5\b\5\2;\5\3\2\2\2<=\7\20\2\2=>\5$\23"+
		"\2>\7\3\2\2\2?B\7\r\2\2@A\7\6\2\2AC\5 \21\2B@\3\2\2\2BC\3\2\2\2CD\3\2"+
		"\2\2DE\7\t\2\2EJ\5$\23\2FG\7&\2\2GI\5$\23\2HF\3\2\2\2IL\3\2\2\2JH\3\2"+
		"\2\2JK\3\2\2\2KM\3\2\2\2LJ\3\2\2\2MO\5\24\13\2NP\5\n\6\2ON\3\2\2\2OP\3"+
		"\2\2\2PQ\3\2\2\2QV\7\35\2\2RU\5\b\5\2SU\5\f\7\2TR\3\2\2\2TS\3\2\2\2UX"+
		"\3\2\2\2VT\3\2\2\2VW\3\2\2\2WY\3\2\2\2XV\3\2\2\2YZ\7\36\2\2Z\t\3\2\2\2"+
		"[\\\7\3\2\2\\c\7\n\2\2]d\7\13\2\2^d\7\5\2\2_`\7\f\2\2`a\5$\23\2ab\7\""+
		"\2\2bd\3\2\2\2c]\3\2\2\2c^\3\2\2\2c_\3\2\2\2d\13\3\2\2\2eh\5$\23\2fh\5"+
		"(\25\2ge\3\2\2\2gf\3\2\2\2hi\3\2\2\2il\7\"\2\2jk\7\3\2\2km\5\20\t\2lj"+
		"\3\2\2\2lm\3\2\2\2mn\3\2\2\2nu\5\16\b\2op\7\35\2\2pq\5\b\5\2qr\7\36\2"+
		"\2rt\3\2\2\2so\3\2\2\2tw\3\2\2\2us\3\2\2\2uv\3\2\2\2v\r\3\2\2\2wu\3\2"+
		"\2\2x\u0081\7\16\2\2y\u0082\5\22\n\2z\u0082\7\21\2\2{\u0082\7\22\2\2|"+
		"\u0082\5$\23\2}\u0082\5 \21\2~\u0082\5\"\22\2\177\u0082\5&\24\2\u0080"+
		"\u0082\5(\25\2\u0081y\3\2\2\2\u0081z\3\2\2\2\u0081{\3\2\2\2\u0081|\3\2"+
		"\2\2\u0081}\3\2\2\2\u0081~\3\2\2\2\u0081\177\3\2\2\2\u0081\u0080\3\2\2"+
		"\2\u0082\u0084\3\2\2\2\u0083\u0085\5\30\r\2\u0084\u0083\3\2\2\2\u0084"+
		"\u0085\3\2\2\2\u0085\17\3\2\2\2\u0086\u0087\t\2\2\2\u0087\21\3\2\2\2\u0088"+
		"\u0089\7\4\2\2\u0089\u008a\5$\23\2\u008a\23\3\2\2\2\u008b\u008c\7\7\2"+
		"\2\u008c\u008e\5\26\f\2\u008d\u008b\3\2\2\2\u008d\u008e\3\2\2\2\u008e"+
		"\u0091\3\2\2\2\u008f\u0090\7\17\2\2\u0090\u0092\5\26\f\2\u0091\u008f\3"+
		"\2\2\2\u0091\u0092\3\2\2\2\u0092\25\3\2\2\2\u0093\u0096\5 \21\2\u0094"+
		"\u0096\7%\2\2\u0095\u0093\3\2\2\2\u0095\u0094\3\2\2\2\u0096\27\3\2\2\2"+
		"\u0097\u0098\5\36\20\2\u0098\u009a\7\35\2\2\u0099\u009b\5\32\16\2\u009a"+
		"\u0099\3\2\2\2\u009a\u009b\3\2\2\2\u009b\u009c\3\2\2\2\u009c\u009f\7\36"+
		"\2\2\u009d\u009e\7&\2\2\u009e\u00a0\5\30\r\2\u009f\u009d\3\2\2\2\u009f"+
		"\u00a0\3\2\2\2\u00a0\31\3\2\2\2\u00a1\u00a6\5\34\17\2\u00a2\u00a3\7#\2"+
		"\2\u00a3\u00a5\5\34\17\2\u00a4\u00a2\3\2\2\2\u00a5\u00a8\3\2\2\2\u00a6"+
		"\u00a4\3\2\2\2\u00a6\u00a7\3\2\2\2\u00a7\33\3\2\2\2\u00a8\u00a6\3\2\2"+
		"\2\u00a9\u00ac\5 \21\2\u00aa\u00ac\5$\23\2\u00ab\u00a9\3\2\2\2\u00ab\u00aa"+
		"\3\2\2\2\u00ac\35\3\2\2\2\u00ad\u00ae\7+\2\2\u00ae\37\3\2\2\2\u00af\u00b1"+
		"\7(\2\2\u00b0\u00af\3\2\2\2\u00b1\u00b2\3\2\2\2\u00b2\u00b0\3\2\2\2\u00b2"+
		"\u00b3\3\2\2\2\u00b3!\3\2\2\2\u00b4\u00b5\5 \21\2\u00b5\u00b6\7$\2\2\u00b6"+
		"\u00b7\5 \21\2\u00b7#\3\2\2\2\u00b8\u00b9\7\33\2\2\u00b9%\3\2\2\2\u00ba"+
		"\u00bb\t\3\2\2\u00bb\'\3\2\2\2\u00bc\u00bd\7\34\2\2\u00bd\u00be\5\36\20"+
		"\2\u00be)\3\2\2\2\27-\65BJOTVcglu\u0081\u0084\u008d\u0091\u0095\u009a"+
		"\u009f\u00a6\u00ab\u00b2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}