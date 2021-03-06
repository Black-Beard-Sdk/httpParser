// Generated from f:\Src\httpParser\src\Black.Beard.Sdk.HttpParser\Grammar\Generator\HtmlPatternLexer.g4 by ANTLR 4.7.1
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class HtmlPatternLexer extends Lexer {
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
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	public static final String[] ruleNames = {
		"AS", "ATTRIBUTE", "ARRAY", "SUB", "SKIP1", "JSON", "NODE", "NEW", "OBJECT", 
		"PROPERTY", "SEARCH", "SELECT", "LIMIT", "USING", "HTML", "TEXT", "STRING", 
		"DECIMAL", "INTEGER", "DATE", "UUID", "BOOLEAN", "TRUE", "FALSE", "CHAR_STRING", 
		"DOLLAR", "LEFT_PAREN", "RIGHT_PAREN", "LEFT_BRACE", "RIGHT_BRACE", "SEMICOLON", 
		"COLON", "COMMA", "DOT", "WILDCARD", "PIPE", "SPACES", "SIMPLE_LETTER", 
		"NUMBER", "SINGLE_LINE_COMMENT", "MULTI_LINE_COMMENT", "NEWLINE", "SPACE", 
		"REGULAR_ID", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", 
		"M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
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


	public HtmlPatternLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "HtmlPatternLexer.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2+\u01e5\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\4\63\t\63\4\64\t"+
		"\64\4\65\t\65\4\66\t\66\4\67\t\67\48\t8\49\t9\4:\t:\4;\t;\4<\t<\4=\t="+
		"\4>\t>\4?\t?\4@\t@\4A\tA\4B\tB\4C\tC\4D\tD\4E\tE\4F\tF\4G\tG\3\2\3\2\3"+
		"\2\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\4\3\4\3\4\3\4\3\4\3\4\3\5"+
		"\3\5\3\5\3\5\3\6\3\6\3\6\3\6\3\6\3\7\3\7\3\7\3\7\3\7\3\b\3\b\3\b\3\b\3"+
		"\b\3\t\3\t\3\t\3\t\3\n\3\n\3\n\3\n\3\n\3\n\3\n\3\13\3\13\3\13\3\13\3\13"+
		"\3\13\3\13\3\13\3\13\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\r\3\r\3\r\3\r\3\r\3"+
		"\r\3\r\3\16\3\16\3\16\3\16\3\16\3\16\3\17\3\17\3\17\3\17\3\17\3\17\3\20"+
		"\3\20\3\20\3\20\3\20\3\21\3\21\3\21\3\21\3\21\3\22\3\22\3\22\3\22\3\22"+
		"\3\22\3\22\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\24\3\24\3\24\3\24"+
		"\3\24\3\24\3\24\3\24\3\25\3\25\3\25\3\25\3\25\3\26\3\26\3\26\3\26\3\26"+
		"\3\27\3\27\3\27\3\27\3\27\3\27\3\27\3\27\3\30\3\30\3\30\3\30\3\30\3\31"+
		"\3\31\3\31\3\31\3\31\3\31\3\32\3\32\3\32\3\32\3\32\7\32\u0127\n\32\f\32"+
		"\16\32\u012a\13\32\3\32\3\32\3\33\3\33\3\34\3\34\3\35\3\35\3\36\3\36\3"+
		"\37\3\37\3 \3 \3!\3!\3\"\3\"\3#\3#\3$\3$\3%\3%\3&\6&\u0145\n&\r&\16&\u0146"+
		"\3&\3&\3\'\3\'\3(\6(\u014e\n(\r(\16(\u014f\3)\3)\3)\3)\7)\u0156\n)\f)"+
		"\16)\u0159\13)\3)\3)\5)\u015d\n)\3)\3)\3*\3*\3*\3*\7*\u0165\n*\f*\16*"+
		"\u0168\13*\3*\3*\3*\3*\3*\3+\5+\u0170\n+\3+\3+\3,\3,\3-\3-\3-\7-\u0179"+
		"\n-\f-\16-\u017c\13-\3.\3.\3.\3.\3/\3/\3/\3/\3\60\3\60\3\60\3\60\3\61"+
		"\3\61\3\61\3\61\3\62\3\62\3\62\3\62\3\63\3\63\3\63\3\63\3\64\3\64\3\64"+
		"\3\64\3\65\3\65\3\65\3\65\3\66\3\66\3\66\3\66\3\67\3\67\3\67\3\67\38\3"+
		"8\38\38\39\39\39\39\3:\3:\3:\3:\3;\3;\3;\3;\3<\3<\3<\3<\3=\3=\3=\3=\3"+
		">\3>\3>\3>\3?\3?\3?\3?\3@\3@\3@\3@\3A\3A\3A\3A\3B\3B\3B\3B\3C\3C\3C\3"+
		"C\3D\3D\3D\3D\3E\3E\3E\3E\3F\3F\3F\3F\3G\3G\3G\3G\3\u0166\2H\3\3\5\4\7"+
		"\5\t\6\13\7\r\b\17\t\21\n\23\13\25\f\27\r\31\16\33\17\35\20\37\21!\22"+
		"#\23%\24\'\25)\26+\27-\30/\31\61\32\63\33\65\34\67\359\36;\37= ?!A\"C"+
		"#E$G%I&K\'M\2O(Q)S*U\2W\2Y+[\2]\2_\2a\2c\2e\2g\2i\2k\2m\2o\2q\2s\2u\2"+
		"w\2y\2{\2}\2\177\2\u0081\2\u0083\2\u0085\2\u0087\2\u0089\2\u008b\2\u008d"+
		"\2\3\2\t\5\2\f\f\17\17))\5\2\13\f\17\17\"\"\4\2C\\c|\3\2\62;\4\2\f\f\17"+
		"\17\4\2\13\13\"\"\5\2%%\62;aa\2\u01d2\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2"+
		"\2\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2"+
		"\23\3\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3"+
		"\2\2\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3"+
		"\2\2\2\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65"+
		"\3\2\2\2\2\67\3\2\2\2\29\3\2\2\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2A\3"+
		"\2\2\2\2C\3\2\2\2\2E\3\2\2\2\2G\3\2\2\2\2I\3\2\2\2\2K\3\2\2\2\2O\3\2\2"+
		"\2\2Q\3\2\2\2\2S\3\2\2\2\2Y\3\2\2\2\3\u008f\3\2\2\2\5\u0092\3\2\2\2\7"+
		"\u009c\3\2\2\2\t\u00a2\3\2\2\2\13\u00a6\3\2\2\2\r\u00ab\3\2\2\2\17\u00b0"+
		"\3\2\2\2\21\u00b5\3\2\2\2\23\u00b9\3\2\2\2\25\u00c0\3\2\2\2\27\u00c9\3"+
		"\2\2\2\31\u00d0\3\2\2\2\33\u00d7\3\2\2\2\35\u00dd\3\2\2\2\37\u00e3\3\2"+
		"\2\2!\u00e8\3\2\2\2#\u00ed\3\2\2\2%\u00f4\3\2\2\2\'\u00fc\3\2\2\2)\u0104"+
		"\3\2\2\2+\u0109\3\2\2\2-\u010e\3\2\2\2/\u0116\3\2\2\2\61\u011b\3\2\2\2"+
		"\63\u0121\3\2\2\2\65\u012d\3\2\2\2\67\u012f\3\2\2\29\u0131\3\2\2\2;\u0133"+
		"\3\2\2\2=\u0135\3\2\2\2?\u0137\3\2\2\2A\u0139\3\2\2\2C\u013b\3\2\2\2E"+
		"\u013d\3\2\2\2G\u013f\3\2\2\2I\u0141\3\2\2\2K\u0144\3\2\2\2M\u014a\3\2"+
		"\2\2O\u014d\3\2\2\2Q\u0151\3\2\2\2S\u0160\3\2\2\2U\u016f\3\2\2\2W\u0173"+
		"\3\2\2\2Y\u0175\3\2\2\2[\u017d\3\2\2\2]\u0181\3\2\2\2_\u0185\3\2\2\2a"+
		"\u0189\3\2\2\2c\u018d\3\2\2\2e\u0191\3\2\2\2g\u0195\3\2\2\2i\u0199\3\2"+
		"\2\2k\u019d\3\2\2\2m\u01a1\3\2\2\2o\u01a5\3\2\2\2q\u01a9\3\2\2\2s\u01ad"+
		"\3\2\2\2u\u01b1\3\2\2\2w\u01b5\3\2\2\2y\u01b9\3\2\2\2{\u01bd\3\2\2\2}"+
		"\u01c1\3\2\2\2\177\u01c5\3\2\2\2\u0081\u01c9\3\2\2\2\u0083\u01cd\3\2\2"+
		"\2\u0085\u01d1\3\2\2\2\u0087\u01d5\3\2\2\2\u0089\u01d9\3\2\2\2\u008b\u01dd"+
		"\3\2\2\2\u008d\u01e1\3\2\2\2\u008f\u0090\7C\2\2\u0090\u0091\7U\2\2\u0091"+
		"\4\3\2\2\2\u0092\u0093\7C\2\2\u0093\u0094\7V\2\2\u0094\u0095\7V\2\2\u0095"+
		"\u0096\7T\2\2\u0096\u0097\7K\2\2\u0097\u0098\7D\2\2\u0098\u0099\7W\2\2"+
		"\u0099\u009a\7V\2\2\u009a\u009b\7G\2\2\u009b\6\3\2\2\2\u009c\u009d\7C"+
		"\2\2\u009d\u009e\7T\2\2\u009e\u009f\7T\2\2\u009f\u00a0\7C\2\2\u00a0\u00a1"+
		"\7[\2\2\u00a1\b\3\2\2\2\u00a2\u00a3\7U\2\2\u00a3\u00a4\7W\2\2\u00a4\u00a5"+
		"\7D\2\2\u00a5\n\3\2\2\2\u00a6\u00a7\7U\2\2\u00a7\u00a8\7M\2\2\u00a8\u00a9"+
		"\7K\2\2\u00a9\u00aa\7R\2\2\u00aa\f\3\2\2\2\u00ab\u00ac\7L\2\2\u00ac\u00ad"+
		"\7U\2\2\u00ad\u00ae\7Q\2\2\u00ae\u00af\7P\2\2\u00af\16\3\2\2\2\u00b0\u00b1"+
		"\7P\2\2\u00b1\u00b2\7Q\2\2\u00b2\u00b3\7F\2\2\u00b3\u00b4\7G\2\2\u00b4"+
		"\20\3\2\2\2\u00b5\u00b6\7P\2\2\u00b6\u00b7\7G\2\2\u00b7\u00b8\7Y\2\2\u00b8"+
		"\22\3\2\2\2\u00b9\u00ba\7Q\2\2\u00ba\u00bb\7D\2\2\u00bb\u00bc\7L\2\2\u00bc"+
		"\u00bd\7G\2\2\u00bd\u00be\7E\2\2\u00be\u00bf\7V\2\2\u00bf\24\3\2\2\2\u00c0"+
		"\u00c1\7R\2\2\u00c1\u00c2\7T\2\2\u00c2\u00c3\7Q\2\2\u00c3\u00c4\7R\2\2"+
		"\u00c4\u00c5\7G\2\2\u00c5\u00c6\7T\2\2\u00c6\u00c7\7V\2\2\u00c7\u00c8"+
		"\7[\2\2\u00c8\26\3\2\2\2\u00c9\u00ca\7U\2\2\u00ca\u00cb\7G\2\2\u00cb\u00cc"+
		"\7C\2\2\u00cc\u00cd\7T\2\2\u00cd\u00ce\7E\2\2\u00ce\u00cf\7J\2\2\u00cf"+
		"\30\3\2\2\2\u00d0\u00d1\7U\2\2\u00d1\u00d2\7G\2\2\u00d2\u00d3\7N\2\2\u00d3"+
		"\u00d4\7G\2\2\u00d4\u00d5\7E\2\2\u00d5\u00d6\7V\2\2\u00d6\32\3\2\2\2\u00d7"+
		"\u00d8\7N\2\2\u00d8\u00d9\7K\2\2\u00d9\u00da\7O\2\2\u00da\u00db\7K\2\2"+
		"\u00db\u00dc\7V\2\2\u00dc\34\3\2\2\2\u00dd\u00de\7W\2\2\u00de\u00df\7"+
		"U\2\2\u00df\u00e0\7K\2\2\u00e0\u00e1\7P\2\2\u00e1\u00e2\7I\2\2\u00e2\36"+
		"\3\2\2\2\u00e3\u00e4\7J\2\2\u00e4\u00e5\7V\2\2\u00e5\u00e6\7O\2\2\u00e6"+
		"\u00e7\7N\2\2\u00e7 \3\2\2\2\u00e8\u00e9\7V\2\2\u00e9\u00ea\7G\2\2\u00ea"+
		"\u00eb\7Z\2\2\u00eb\u00ec\7V\2\2\u00ec\"\3\2\2\2\u00ed\u00ee\7U\2\2\u00ee"+
		"\u00ef\7V\2\2\u00ef\u00f0\7T\2\2\u00f0\u00f1\7K\2\2\u00f1\u00f2\7P\2\2"+
		"\u00f2\u00f3\7I\2\2\u00f3$\3\2\2\2\u00f4\u00f5\7F\2\2\u00f5\u00f6\7G\2"+
		"\2\u00f6\u00f7\7E\2\2\u00f7\u00f8\7K\2\2\u00f8\u00f9\7O\2\2\u00f9\u00fa"+
		"\7C\2\2\u00fa\u00fb\7N\2\2\u00fb&\3\2\2\2\u00fc\u00fd\7K\2\2\u00fd\u00fe"+
		"\7P\2\2\u00fe\u00ff\7V\2\2\u00ff\u0100\7G\2\2\u0100\u0101\7I\2\2\u0101"+
		"\u0102\7G\2\2\u0102\u0103\7T\2\2\u0103(\3\2\2\2\u0104\u0105\7F\2\2\u0105"+
		"\u0106\7C\2\2\u0106\u0107\7V\2\2\u0107\u0108\7G\2\2\u0108*\3\2\2\2\u0109"+
		"\u010a\7W\2\2\u010a\u010b\7W\2\2\u010b\u010c\7K\2\2\u010c\u010d\7F\2\2"+
		"\u010d,\3\2\2\2\u010e\u010f\7D\2\2\u010f\u0110\7Q\2\2\u0110\u0111\7Q\2"+
		"\2\u0111\u0112\7N\2\2\u0112\u0113\7G\2\2\u0113\u0114\7C\2\2\u0114\u0115"+
		"\7P\2\2\u0115.\3\2\2\2\u0116\u0117\7v\2\2\u0117\u0118\7t\2\2\u0118\u0119"+
		"\7w\2\2\u0119\u011a\7g\2\2\u011a\60\3\2\2\2\u011b\u011c\7h\2\2\u011c\u011d"+
		"\7c\2\2\u011d\u011e\7n\2\2\u011e\u011f\7u\2\2\u011f\u0120\7g\2\2\u0120"+
		"\62\3\2\2\2\u0121\u0128\7)\2\2\u0122\u0127\n\2\2\2\u0123\u0124\7)\2\2"+
		"\u0124\u0127\7)\2\2\u0125\u0127\5U+\2\u0126\u0122\3\2\2\2\u0126\u0123"+
		"\3\2\2\2\u0126\u0125\3\2\2\2\u0127\u012a\3\2\2\2\u0128\u0126\3\2\2\2\u0128"+
		"\u0129\3\2\2\2\u0129\u012b\3\2\2\2\u012a\u0128\3\2\2\2\u012b\u012c\7)"+
		"\2\2\u012c\64\3\2\2\2\u012d\u012e\7&\2\2\u012e\66\3\2\2\2\u012f\u0130"+
		"\7*\2\2\u01308\3\2\2\2\u0131\u0132\7+\2\2\u0132:\3\2\2\2\u0133\u0134\7"+
		"}\2\2\u0134<\3\2\2\2\u0135\u0136\7\177\2\2\u0136>\3\2\2\2\u0137\u0138"+
		"\7=\2\2\u0138@\3\2\2\2\u0139\u013a\7<\2\2\u013aB\3\2\2\2\u013b\u013c\7"+
		".\2\2\u013cD\3\2\2\2\u013d\u013e\7\60\2\2\u013eF\3\2\2\2\u013f\u0140\7"+
		",\2\2\u0140H\3\2\2\2\u0141\u0142\7~\2\2\u0142J\3\2\2\2\u0143\u0145\t\3"+
		"\2\2\u0144\u0143\3\2\2\2\u0145\u0146\3\2\2\2\u0146\u0144\3\2\2\2\u0146"+
		"\u0147\3\2\2\2\u0147\u0148\3\2\2\2\u0148\u0149\b&\2\2\u0149L\3\2\2\2\u014a"+
		"\u014b\t\4\2\2\u014bN\3\2\2\2\u014c\u014e\t\5\2\2\u014d\u014c\3\2\2\2"+
		"\u014e\u014f\3\2\2\2\u014f\u014d\3\2\2\2\u014f\u0150\3\2\2\2\u0150P\3"+
		"\2\2\2\u0151\u0152\7/\2\2\u0152\u0153\7/\2\2\u0153\u0157\3\2\2\2\u0154"+
		"\u0156\n\6\2\2\u0155\u0154\3\2\2\2\u0156\u0159\3\2\2\2\u0157\u0155\3\2"+
		"\2\2\u0157\u0158\3\2\2\2\u0158\u015c\3\2\2\2\u0159\u0157\3\2\2\2\u015a"+
		"\u015d\5U+\2\u015b\u015d\7\2\2\3\u015c\u015a\3\2\2\2\u015c\u015b\3\2\2"+
		"\2\u015d\u015e\3\2\2\2\u015e\u015f\b)\3\2\u015fR\3\2\2\2\u0160\u0161\7"+
		"\61\2\2\u0161\u0162\7,\2\2\u0162\u0166\3\2\2\2\u0163\u0165\13\2\2\2\u0164"+
		"\u0163\3\2\2\2\u0165\u0168\3\2\2\2\u0166\u0167\3\2\2\2\u0166\u0164\3\2"+
		"\2\2\u0167\u0169\3\2\2\2\u0168\u0166\3\2\2\2\u0169\u016a\7,\2\2\u016a"+
		"\u016b\7\61\2\2\u016b\u016c\3\2\2\2\u016c\u016d\b*\3\2\u016dT\3\2\2\2"+
		"\u016e\u0170\7\17\2\2\u016f\u016e\3\2\2\2\u016f\u0170\3\2\2\2\u0170\u0171"+
		"\3\2\2\2\u0171\u0172\7\f\2\2\u0172V\3\2\2\2\u0173\u0174\t\7\2\2\u0174"+
		"X\3\2\2\2\u0175\u017a\5M\'\2\u0176\u0179\5M\'\2\u0177\u0179\t\b\2\2\u0178"+
		"\u0176\3\2\2\2\u0178\u0177\3\2\2\2\u0179\u017c\3\2\2\2\u017a\u0178\3\2"+
		"\2\2\u017a\u017b\3\2\2\2\u017bZ\3\2\2\2\u017c\u017a\3\2\2\2\u017d\u017e"+
		"\7c\2\2\u017e\u017f\7~\2\2\u017f\u0180\7C\2\2\u0180\\\3\2\2\2\u0181\u0182"+
		"\7d\2\2\u0182\u0183\7~\2\2\u0183\u0184\7D\2\2\u0184^\3\2\2\2\u0185\u0186"+
		"\7e\2\2\u0186\u0187\7~\2\2\u0187\u0188\7E\2\2\u0188`\3\2\2\2\u0189\u018a"+
		"\7f\2\2\u018a\u018b\7~\2\2\u018b\u018c\7F\2\2\u018cb\3\2\2\2\u018d\u018e"+
		"\7g\2\2\u018e\u018f\7~\2\2\u018f\u0190\7G\2\2\u0190d\3\2\2\2\u0191\u0192"+
		"\7h\2\2\u0192\u0193\7~\2\2\u0193\u0194\7H\2\2\u0194f\3\2\2\2\u0195\u0196"+
		"\7i\2\2\u0196\u0197\7~\2\2\u0197\u0198\7I\2\2\u0198h\3\2\2\2\u0199\u019a"+
		"\7j\2\2\u019a\u019b\7~\2\2\u019b\u019c\7J\2\2\u019cj\3\2\2\2\u019d\u019e"+
		"\7k\2\2\u019e\u019f\7~\2\2\u019f\u01a0\7K\2\2\u01a0l\3\2\2\2\u01a1\u01a2"+
		"\7l\2\2\u01a2\u01a3\7~\2\2\u01a3\u01a4\7L\2\2\u01a4n\3\2\2\2\u01a5\u01a6"+
		"\7m\2\2\u01a6\u01a7\7~\2\2\u01a7\u01a8\7M\2\2\u01a8p\3\2\2\2\u01a9\u01aa"+
		"\7n\2\2\u01aa\u01ab\7~\2\2\u01ab\u01ac\7N\2\2\u01acr\3\2\2\2\u01ad\u01ae"+
		"\7o\2\2\u01ae\u01af\7~\2\2\u01af\u01b0\7O\2\2\u01b0t\3\2\2\2\u01b1\u01b2"+
		"\7p\2\2\u01b2\u01b3\7~\2\2\u01b3\u01b4\7P\2\2\u01b4v\3\2\2\2\u01b5\u01b6"+
		"\7q\2\2\u01b6\u01b7\7~\2\2\u01b7\u01b8\7Q\2\2\u01b8x\3\2\2\2\u01b9\u01ba"+
		"\7r\2\2\u01ba\u01bb\7~\2\2\u01bb\u01bc\7R\2\2\u01bcz\3\2\2\2\u01bd\u01be"+
		"\7s\2\2\u01be\u01bf\7~\2\2\u01bf\u01c0\7S\2\2\u01c0|\3\2\2\2\u01c1\u01c2"+
		"\7t\2\2\u01c2\u01c3\7~\2\2\u01c3\u01c4\7T\2\2\u01c4~\3\2\2\2\u01c5\u01c6"+
		"\7u\2\2\u01c6\u01c7\7~\2\2\u01c7\u01c8\7U\2\2\u01c8\u0080\3\2\2\2\u01c9"+
		"\u01ca\7v\2\2\u01ca\u01cb\7~\2\2\u01cb\u01cc\7V\2\2\u01cc\u0082\3\2\2"+
		"\2\u01cd\u01ce\7w\2\2\u01ce\u01cf\7~\2\2\u01cf\u01d0\7W\2\2\u01d0\u0084"+
		"\3\2\2\2\u01d1\u01d2\7x\2\2\u01d2\u01d3\7~\2\2\u01d3\u01d4\7X\2\2\u01d4"+
		"\u0086\3\2\2\2\u01d5\u01d6\7y\2\2\u01d6\u01d7\7~\2\2\u01d7\u01d8\7Y\2"+
		"\2\u01d8\u0088\3\2\2\2\u01d9\u01da\7z\2\2\u01da\u01db\7~\2\2\u01db\u01dc"+
		"\7Z\2\2\u01dc\u008a\3\2\2\2\u01dd\u01de\7{\2\2\u01de\u01df\7~\2\2\u01df"+
		"\u01e0\7[\2\2\u01e0\u008c\3\2\2\2\u01e1\u01e2\7|\2\2\u01e2\u01e3\7~\2"+
		"\2\u01e3\u01e4\7\\\2\2\u01e4\u008e\3\2\2\2\r\2\u0126\u0128\u0146\u014f"+
		"\u0157\u015c\u0166\u016f\u0178\u017a\4\b\2\2\2\3\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}