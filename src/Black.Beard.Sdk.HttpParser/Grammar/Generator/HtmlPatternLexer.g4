/**
 * HtmlPattern Parser
 *
 * Copyright (c) 2009-2011 Alexandre Porcelli <alexandre.porcelli@gmail.com>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

lexer grammar HtmlPatternLexer;

AS :        'AS';

ATTRIBUTE : 'ATTRIBUTE';
ARRAY :     'ARRAY';

SUB :       'SUB';

SKIP1 :     'SKIP';

JSON :      'JSON';

NODE :      'NODE';

NEW :       'NEW';

OBJECT :    'OBJECT';

PROPERTY :  'PROPERTY';

SEARCH :    'SEARCH';
SELECT :    'SELECT';

LIMIT :     'LIMIT';

USING :     'USING';

STRING :    'STRING';
DECIMAL :   'DECIMAL';
INTEGER :   'INTEGER';
DATE :      'DATE';
UUID :      'UUID';
BOOLEAN :   'BOOLEAN';

// and a superfluous subtoken typecasting of the "QUOTE"
CHAR_STRING :  '\'' (~('\'' | '\r' | '\n') | '\'\'' | NEWLINE)+ '\'';


LEFT_PAREN:             '(';
RIGHT_PAREN:            ')';

LEFT_BRACE :            '{';
RIGHT_BRACE :           '}';

SEMICOLON :             ';';
COLON :                 ':';
COMMA :                 ',';
DOT :                   '.';
WILDCARD :              '*';
PIPE :                  '|';
SPACES: [ \t\r\n]+ -> skip;
    
// Rule #504 <SIMPLE_LETTER> - simple_latin _letter was generalised into SIMPLE_LETTER
//  Unicode is yet to be implemented - see NSF0
fragment
SIMPLE_LETTER
    : [A-Za-z]
    ;

NUMBER
    : [0-9]+
    ;

// Rule #097 <COMMENT>
SINGLE_LINE_COMMENT: '--' ~('\r' | '\n')* (NEWLINE | EOF)   -> channel(HIDDEN);
MULTI_LINE_COMMENT:  '/*' .*? '*/'                          -> channel(HIDDEN);

// SQL*Plus prompt
// TODO should be grammar rule, but tricky to implement

fragment
NEWLINE: '\r'? '\n';
    
fragment
SPACE: [ \t];

REGULAR_ID: SIMPLE_LETTER (SIMPLE_LETTER | '$' | '_' | '#' | [0-9])*;


fragment
A : 'a|A';

fragment
B : 'b|B';

fragment
C : 'c|C';

fragment
D : 'd|D';

fragment
E : 'e|E';

fragment
F : 'f|F';

fragment
G : 'g|G';

fragment
H : 'h|H';

fragment
I : 'i|I';

fragment
J : 'j|J';

fragment
K : 'k|K';

fragment
L : 'l|L';

fragment
M : 'm|M';

fragment
N : 'n|N';

fragment
O : 'o|O';

fragment
P : 'p|P';

fragment
Q : 'q|Q';

fragment
R : 'r|R';

fragment
S : 's|S';

fragment
T : 't|T';

fragment
U : 'u|U';

fragment
V : 'v|V';

fragment
W : 'w|W';

fragment
X : 'x|X';

fragment
Y : 'y|Y';

fragment
Z : 'z|Z';
