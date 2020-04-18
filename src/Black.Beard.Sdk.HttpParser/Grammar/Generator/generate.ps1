# antlr-4.7-complete.jar must be preset 
# http://www.antlr.org/download/antlr-4.7-complete.jar

java.exe -jar antlr-4.7-complete.jar -Dlanguage=CSharp HtmlPatternLexer.g4 -visitor -no-listener -package Bb.Sdk.HttpParser.Grammar.Generated
java.exe -jar antlr-4.7-complete.jar -Dlanguage=CSharp HtmlPatternParser.g4 -visitor -no-listener -package Bb.Sdk.HttpParser.Grammar.Generated