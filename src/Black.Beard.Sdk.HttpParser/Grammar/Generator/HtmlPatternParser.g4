/**
 * HtmlPattern engine Parser
 *
 * Copyright (c) 2009-2011 Gael beard <g.beard@pickup-services.com>
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

parser grammar HtmlPatternParser;

options { 
    // memoize=True;
    tokenVocab=HtmlPatternLexer; 
    }

script :
    using*
	(unit_statement SEMICOLON)* EOF
    ;

unit_statement : 
    search
    ;

using :
    USING text
    ;

search : 
    SEARCH (SUB numbers)? NODE text (PIPE text)* pagination output? LEFT_PAREN (search | select)* RIGHT_PAREN
    ;

output : 
    AS NEW 
    (
          OBJECT 
        | ARRAY 
        | PROPERTY text COLON
    )
    ;

select : 
    (text | variable) COLON (AS type)? selectItem (LEFT_PAREN search RIGHT_PAREN)*
    ;

selectItem : SELECT (attribute | HTML | TEXT | text | numbers | float | boolean | variable) function?;

type : STRING | DECIMAL | INTEGER | DATE | UUID | BOOLEAN;

attribute :
    ATTRIBUTE text
    ;

pagination : 
    (SKIP1 c1=count)? (LIMIT c2=count)?
    ;

count : 
    (numbers | WILDCARD)
    ;

function : key LEFT_PAREN arguments? RIGHT_PAREN (PIPE function)?;

arguments : 
     argument (COMMA argument)*
    ;

argument : numbers | text;

key : REGULAR_ID;
numbers : NUMBER+;
float : numbers DOT numbers;
text : CHAR_STRING;
boolean : TRUE | FALSE;
variable : DOLLAR key;