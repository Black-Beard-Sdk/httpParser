# httpParser
Language for parse http model and extract json

## Syntaxe for write valid matching
```Antlr
script :
    using*
	(unit_statement SEMICOLON)* EOF
    ;

unit_statement : search;

using : USING text;

search : SEARCH (SUB numbers)? NODE text (PIPE text)* pagination output? LEFT_PAREN (search | select)* RIGHT_PAREN;

output : 
    AS NEW 
    (
          OBJECT 
        | ARRAY 
        | PROPERTY text COLON
    )
    ;

select : text COLON (AS type)? SELECT attribute? function? (LEFT_PAREN search RIGHT_PAREN)*;

type : STRING | DECIMAL | INTEGER | DATE | UUID | BOOLEAN;

attribute : ATTRIBUTE text;

pagination : (SKIP1 c1=count)? (LIMIT c2=count)?;

count : (numbers | WILDCARD);

function : key LEFT_PAREN arguments? RIGHT_PAREN (PIPE function)?;

arguments : argument (COMMA argument)*;

argument : numbers | text;

key : REGULAR_ID;
numbers : NUMBER+;
text : CHAR_STRING;

```

## sample of matching
```
-- discover all methods of the class 'ImportHttp.Test'
USING 'ImportHttp.Test, ImportHttp'

-- search all xpath '//div[@class="bloc-content bloc-content--bordered"]/div'
--		limit items to 2 items
--		create an array that contains all result from sub request
SEARCH NODE '//div[@class="bloc-content bloc-content--bordered"]/div' LIMIT 2 AS NEW ARRAY
(

	--	search all xpath 'div[@class="item"]'
	--		if items not match with the xpath the process can search in 3 sub level
	--		all properties collected in sub request will be injected in object
	SEARCH SUB 3 NODE 'div[@class="item"]' AS NEW OBJECT
	(

		--	search all xpath 'div[@class="item"]'
		SEARCH NODE 'div/div[@class="meta-date"]'
		(
			-- create a property named 'date'. the value is the text contained in the node 'div'.
			--		Trim() is a function called just after read.
			--		by default you can call all methods of the type String
			'date'  :   SELECT Trim()
		)
		
		-- search all node 'a' and take only the first item
		SEARCH NODE 'a' LIMIT 1
        (
			-- create a property named 'href'. the value is the text contained in the attribute 'href'
			--		Trim() is a function called just after read.
			--		the function MyFunction() is a method discover in the class '' specified un the clause using
			'href'  :   SELECT ATTRIBUTE 'href' Trim() MyFunction()
        )
        
	)

);
```

## sample of class with a method to discover
```CSharp

public static class Test
    {

        static Test()
        {
            _reg = new Regex(@"-[A-Z]{2,2}\d+", RegexOptions.None);
        }

        public static string MyFunction(string test)
        {

            var e = _reg.Match(test);
            if (e.Success)
                return e.Value.Substring(1);

            return test;

        }

        private static readonly Regex _reg;


    }

```

## How to use
```CSharp

    // Load configuration
    var sb = new StringBuilder("SEARCH NODE '//div'");
    var parser = ReaderHtmlParser.ParseString(sb, "name of the filename that contains configuration");
    this._config = parser.Parse();
    
    // create a new Parser
    var _visitor = new ExtractDataVisitor(this._config);

    var sb = new StringBuilder("<html><div></div><div><div></div><div><div></div></div></div></div><div></div></html>");
    JToken jtoken = this._visitor.Run(new StringBuilder(richTextBoxPlain.Text));

    string text = jtoken?.ToString();

```