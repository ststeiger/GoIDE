﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goide.aspx.cs" Inherits="GoIDE.goide" %>
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

    <!--
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/3024-day.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/3024-night.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/abcdef.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/ambiance.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/base16-dark.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/base16-light.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/blackboard.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/cobalt.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/colorforth.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/dracula.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/eclipse.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/elegant.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/erlang-dark.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/icecoder.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/lesser-dark.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/liquibyte.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/material.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/mbo.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/mdn-like.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/midnight.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/monokai.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/neat.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/neo.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/night.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/paraiso-dark.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/paraiso-light.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/pastel-on-dark.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/rubyblue.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/seti.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/solarized.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/the-matrix.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/tomorrow-night-bright.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/tomorrow-night-eighties.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/ttcn.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/twilight.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/vibrant-ink.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/xq-dark.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/xq-light.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/yeti.css" />
    <link rel="stylesheet" href="Scripts/CodeMirror/theme/zenburn.css" />
    -->


    <script src="Scripts/CodeMirror/codemirror.js"></script>
    <script src="Scripts/CodeMirror/addon/edit/matchbrackets.js"></script>
    <script src="Scripts/CodeMirror/modes/go/go.js"></script>
    <!--
    <link rel="stylesheet" href="Scripts/CodeMirror/docs.css">
    -->

    <style>
        .CodeMirror
        {
            border: 1px solid #999;
            background: #ffc;
        }
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
            matchBrackets: true,
            indentUnit: 8,
            tabSize: 8,
            indentWithTabs: true,
            mode: "text/x-go"
        });

        editor.setSize("100%", "100%");
        
    </script>

    <p><strong>MIME type:</strong> <code>text/x-go</code></p>
        </div>
    </form>
</body>
</html>
