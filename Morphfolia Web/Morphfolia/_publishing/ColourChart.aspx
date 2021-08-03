<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ColourChart.aspx.cs" Inherits="_publishing_ColourChart" %>

<!-- Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  -->



<%@ Register assembly="Morphfolia.WebControls" namespace="Morphfolia.WebControls" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hex Code Colour Chart</title>
<script language="javascript" type="text/javascript">
<!--

function Button1_onclick() {

}

function c1R_onclick() {

}

function Button5_onclick() {
    document.forms[0].txtC2R.value = document.forms[0].txtC1R.value;
}

function Button4_onclick() {
    document.forms[0].txtC2G.value = document.forms[0].txtC1G.value;
}

function Button3_onclick() {
    document.forms[0].txtC2B.value = document.forms[0].txtC1B.value;
}

// -->
</script>
</head>
<body>
    <form id="form1" runat="server">



    <table cellpadding=2 cellspacing=0 style="margin: 10px;">
    <tr><td>&nbsp;</td><td>Chart 1 (RGB)</td><td>&nbsp;</td><td>Chart 2 (RGB)</td></tr>
        <tr>
            <td>R</td>
            <td><asp:TextBox ID="txtC1R" runat="server" Width="274px"></asp:TextBox></td>
            <td><input id="Button5" type="button" value="&gt;&gt;" onclick="return Button5_onclick()" /></td>
            <td><asp:TextBox ID="txtC2R" runat="server" Width="274px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>G</td>
            <td><asp:TextBox ID="txtC1G" runat="server" Width="274px"></asp:TextBox></td>
            <td><input id="Button4" type="button" value="&gt;&gt;" onclick="return Button4_onclick()" /></td>
            <td><asp:TextBox ID="txtC2G" runat="server" Width="274px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>B</td>
            <td><asp:TextBox ID="txtC1B" runat="server" Width="274px"></asp:TextBox></td>
            <td><input id="Button3" type="button" value="&gt;&gt;" onclick="return Button3_onclick()" /></td>
            <td><asp:TextBox ID="txtC2B" runat="server" Width="274px"></asp:TextBox></td>
        </tr>
    </table>
    
    <table cellpadding=2 cellspacing=0 style="margin: 10px;">
        <tr>
            <td>Cell Padding <asp:TextBox ID="txtCellPadding" runat="server" Width="43px">0</asp:TextBox></td>
            <td>Cell Spacing <asp:TextBox ID="txtCellSpacing" runat="server" Width="43px">1</asp:TextBox></td>
            <td>Cell Width <asp:TextBox ID="txtCellWidth" runat="server" Width="43px">15</asp:TextBox></td>
            <td>Cell Height <asp:TextBox ID="txtCellHeight" runat="server" Width="43px">15</asp:TextBox></td>
            </tr>
            <tr>
            <td colspan=2>Border Style <asp:TextBox ID="txtBorderStyle" runat="server" Width="139px">1px solid #666666;</asp:TextBox></td>
            <td colspan=2><asp:CheckBox ID="chkbxShowHexCode" runat="server" Text="Show Hex Code" /></td>
        </tr>
    </table>
    
    <table cellpadding=2 cellspacing=0 style="margin: 10px;"><tr>
    <td><asp:Button ID="btnCoarseRange" runat="server" Text="Web-safe" onclick="btnCoarseRange_Click" /></td>
    <td><asp:Button ID="FullRange" runat="server" Text="Full" onclick="FullRange_Click" /></td>
    <td><asp:Button ID="Range" runat="server" Text="SuperFine" onclick="Range_Click" /></td>
    <td><asp:Button ID="btnSummary" runat="server" onclick="btnR_Click" Text="Summary" /></td>
    <td><asp:Button ID="Button1" runat="server" Text="Display Colour-Codes" onclick="Button1_Click1" Font-Bold="True" /></td>
    </tr></table>
    
    <table cellpadding=2 cellspacing=0>
        <tr>
            <td valign=top><cc1:ColourChart ID="ColourChart1" runat="server" /></td>
            <td>&nbsp;</td>
            <td valign=top><cc1:ColourChart ID="ColourChart2" runat="server" /></td>
        </tr>
    </table>
    
    </form>

</body>
</html>
