<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goide.aspx.cs" Inherits="GoIDE.goide" %>
<!doctype html>
<html>
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta charset="utf-8">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="cache-control" content="max-age=0" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="expires" content="0" />
    <meta http-equiv="expires" content="Tue, 01 Jan 1980 1:00:00 GMT" />
    <meta http-equiv="pragma" content="no-cache" />
    <title>CodeMirror: Go mode</title>

    <style type="text/css" media="all">

        html, body, form
        {
            width: 100%; height: 100%;
            margin: 0px; padding: 0px;
            overflow:auto
        }
        

        #wrapper
        {
            display: block;
            width: calc(100% - 10mm);
            height: calc(95%- 10mm);
            margin: 5mm;
        }

    </style>


    <link rel="stylesheet" href="Scripts/CodeMirror/codemirror.css" />
    <!--
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/elegant.css" />
    -->
    
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/<asp:Literal ID="litTheme" runat="server"></asp:Literal>.css" />

    <script src="Scripts/CodeMirror/codemirror.js"></script>
    <script src="Scripts/CodeMirror/addon/selection/active-line.js"></script>
    <script src="Scripts/CodeMirror/addon/edit/matchbrackets.js"></script>
    <script src="Scripts/CodeMirror/modes/go/go.js"></script>

    <style type="text/css" media="all">
        .CodeMirror
        {
            border: 1px solid #999;
            background: #ffc;
        }

        .breakpoints {width: .8em;}
        .breakpoint { color: #822; }

    </style>
</head>
<body>
<form id="form1" runat="server">
    <div id="wrapper">
    <asp:DropDownList ID="ddThemes" runat="server" AutoPostBack="true"></asp:DropDownList>

    <textarea id="code" name="code" style="width: 100%; height: 100%;">
// Prime Sieve in Go.
// Taken from the Go specification.
// Copyright © The Go Authors.

package main

import "fmt"

// Send the sequence 2, 3, 4, ... to channel 'ch'.
func generate(ch chan&lt;- int) {
	for i := 2; ; i++ {
		ch &lt;- i  // Send 'i' to channel 'ch'
	}
}

// Copy the values from channel 'src' to channel 'dst',
// removing those divisible by 'prime'.
func filter(src &lt;-chan int, dst chan&lt;- int, prime int) {
	for i := range src {    // Loop over values received from 'src'.
		if i%prime != 0 {
			dst &lt;- i  // Send 'i' to channel 'dst'.
		}
	}
}

// The prime sieve: Daisy-chain filter processes together.
func sieve() {
	ch := make(chan int)  // Create a new channel.
	go generate(ch)       // Start generate() as a subprocess.
	for {
		prime := &lt;-ch
		fmt.Print(prime, "\n")
		ch1 := make(chan int)
		go filter(ch, ch1, prime)
		ch = ch1
	}
}

func main() {
	sieve()
}
</textarea>
 

    <script>
        
        var editor = CodeMirror.fromTextArea(document.getElementById("code"), {
            // theme: "3024-day",
            //theme: "elegant",
            // theme: "dracula",
            theme: "<asp:Literal id="litThemeName" runat="server" />",
            gutters: ["CodeMirror-linenumbers", "breakpoints"],
            lineNumbers: true,
            styleActiveLine: true,
            matchBrackets: true,
            indentUnit: 8,
            tabSize: 8,
            indentWithTabs: true,
            mode: "text/x-go"
            });
          

        editor.setSize("100%", "100%");
        
        editor.on("gutterClick", function(cm, n) {
            var info = cm.lineInfo(n);
            cm.setGutterMarker(n, "breakpoints", info.gutterMarkers ? null : makeMarker());
        });

        function makeMarker() {
            var marker = document.createElement("div");
            marker.style.color = "#822";
            marker.innerHTML = "●";
            return marker;
        }

    </script>
    	
        </div>
    </form>
</body>
</html>
