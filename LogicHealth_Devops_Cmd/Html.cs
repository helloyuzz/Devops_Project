using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicHealth_Devops {
    class Html {
        internal static string CreateHtml(string url,string temp1) {
            StringBuilder builder = new StringBuilder();
            builder.Append("<HTML>\r\n");
            builder.Append("  <HEAD>\r\n");
            builder.Append("    <TITLE>CSSD打印助手</TITLE>\r\n");
            builder.Append("    <META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html; charset=utf-8\" />\r\n");
            builder.Append("    <STYLE TYPE=\"text/css\">\r\n");
            builder.Append("<!--\r\n");
            builder.Append("BODY{margin-top:20px; margin-left:20px; margin-right:20px; color:#000000; font-family:Tahoma; background-color:white}\r\n");
            builder.Append("A:link {font-weight:normal; color:#000066; text-decoration:none}\r\n");
            builder.Append("A:visited {font-weight:normal; color:#000066; text-decoration:none}\r\n");
            builder.Append("A:active {font-weight:normal; text-decoration:none}\r\n");
            builder.Append("A:hover {font-weight:normal; color:#FF6600; text-decoration:none}\r\n");
            builder.Append("P {margin-top:0px; margin-bottom:12px; color:#000000; font-family:Tahoma}\r\n");
            builder.Append("PRE {border-right:#f0f0e0 1px solid; padding-right:5px; border-top:#f0f0e0 1px solid; margin-top:-5px; padding-left:5px; font-size:x-small; padding-bottom:5px; border-left:#f0f0e0 1px solid; padding-top:5px; border-bottom:#f0f0e0 1px solid; font-family:Courier New; background-color:#e5e5cc}\r\n");
            builder.Append("TD {font-size:12px; color:#000000; font-family:Tahoma}\r\n");
            builder.Append("H2 {border-top: #003366 1px solid; margin-top:25px; font-weight:bold; font-size:1.5em; margin-bottom:10px; margin-left:-15px; color:#003366}\r\n");
            builder.Append("H3 {margin-top:10px; font-size: 1.1em; margin-bottom: 10px; margin-left: -15px; color: #000000}\r\n");
            builder.Append("UL {margin-top:10px; margin-left:20px}\r\n");
            builder.Append("OL {margin-top:10px; margin-left:20px}\r\n");
            builder.Append("LI {margin-top:10px; color: #000000}\r\n");
            builder.Append("FONT.value {font-weight:bold; color:darkblue}\r\n");
            builder.Append("FONT.key {font-weight: bold; color: darkgreen}\r\n");
            builder.Append(".divTag {border:1px; border-style:solid; background-color:#FFFFFF; text-decoration:none; height:auto; width:auto; background-color:#cecece}\r\n");
            builder.Append(".BannerColumn {background-color:#000000}\r\n");
            builder.Append(".Banner {border:0; padding:0; height:8px; margin-top:0px; color:#ffffff; filter:progid:DXImageTransform.Microsoft.Gradient(GradientType=1,StartColorStr='#1c5280',EndColorStr='#FFFFFF');}\r\n");
            builder.Append(".BannerTextCompany {font:bold; font-size:18pt; color:#cecece; font-family:Tahoma; height:0px; margin-top:0; margin-left:8px; margin-bottom:0; padding:0px; white-space:nowrap; filter:progid:DXImageTransform.Microsoft.dropshadow(OffX=2,OffY=2,Color='black',Positive='true');}\r\n");
            builder.Append(".BannerTextApplication {font:bold; font-size:18pt; font-family:Tahoma; height:0px; margin-top:0; margin-left:8px; margin-bottom:0; padding:0px; white-space:nowrap; filter:progid:DXImageTransform.Microsoft.dropshadow(OffX=2,OffY=2,Color='black',Positive='true');}\r\n");
            builder.Append(".BannerText {font:bold; font-size:18pt; font-family:Tahoma; height:0px; margin-top:0; margin-left:8px; margin-bottom:0; padding:0px; filter:progid:DXImageTransform.Microsoft.dropshadow(OffX=2,OffY=2,Color='black',Positive='true');}\r\n");
            builder.Append(".BannerSubhead {border:0; padding:0; height:16px; margin-top:0px; margin-left:10px; color:#ffffff; filter:progid:DXImageTransform.Microsoft.Gradient(GradientType=1,StartColorStr='#4B3E1A',EndColorStr='#FFFFFF');}\r\n");
            builder.Append(".BannerSubheadText {font:bold; height:11px; font-size:11px; font-family:Tahoma; margin-top:1; margin-left:10; filter:progid:DXImageTransform.Microsoft.dropshadow(OffX=2,OffY=2,Color='black',Positive='true');}\r\n");
            builder.Append(".FooterRule {border:0; padding:0; height:1px; margin:0px; color:#ffffff; filter:progid:DXImageTransform.Microsoft.Gradient(GradientType=1,StartColorStr='#4B3E1A',EndColorStr='#FFFFFF');}\r\n");
            builder.Append(".FooterText {font-size:11px; font-weight:normal; text-decoration:none; font-family:Tahoma; margin-top:10; margin-left:0px; margin-bottom:2; padding:0px; color:#999999; white-space:nowrap}\r\n");
            builder.Append(".FooterText A:link {font-weight:normal; color:#999999; text-decoration:underline}\r\n");
            builder.Append(".FooterText A:visited {font-weight:normal; color:#999999; text-decoration:underline}\r\n");
            builder.Append(".FooterText A:active {font-weight:normal; color:#999999; text-decoration:underline}\r\n");
            builder.Append(".FooterText A:hover {font-weight:normal; color:#FF6600; text-decoration:underline}\r\n");
            builder.Append(".ClickOnceInfoText {font-size:11px; font-weight:normal; text-decoration:none; font-family:Tahoma; margin-top:0; margin-right:2px; margin-bottom:0; padding:0px; color:#000000}\r\n");
            builder.Append(".InstallTextStyle {font:bold; font-size:14pt; font-family:Tahoma; a:#FF0000; text-decoration:None}\r\n");
            builder.Append(".DetailsStyle {margin-left:30px}\r\n");
            builder.Append(".ItemStyle {margin-left:-15px; font-weight:bold}\r\n");
            builder.Append(".StartColorStr {background-color:#4B3E1A}\r\n");
            builder.Append(".JustThisApp A:link {font-weight:normal; color:#000066; text-decoration:underline}\r\n");
            builder.Append(".JustThisApp A:visited {font-weight:normal; color:#000066; text-decoration:underline}\r\n");
            builder.Append(".JustThisApp A:active {font-weight:normal; text-decoration:underline}\r\n");
            builder.Append(".JustThisApp A:hover {font-weight:normal; color:#FF6600; text-decoration:underline}\r\n");
            builder.Append("-->\r\n");
            builder.Append("</STYLE>\r\n");
            builder.Append("</HEAD>\r\n");
            builder.Append("  <BODY>\r\n");
            builder.Append("    <TABLE WIDTH=\"100%\" CELLPADDING=\"0\" CELLSPACING=\"2\" BORDER=\"0\">\r\n");
            builder.Append("<!-- Begin Banner -->\r\n");
            builder.Append("<TR><TD><TABLE CELLPADDING=\"2\" CELLSPACING=\"0\" BORDER=\"0\" BGCOLOR=\"#cecece\" WIDTH=\"100%\"><TR><TD><TABLE BGCOLOR=\"#1c5280\" WIDTH=\"100%\" CELLPADDING=\"0\" CELLSPACING=\"0\" BORDER=\"0\"><TR><TD CLASS=\"Banner\" /></TR><TR><TD CLASS=\"Banner\"><SPAN CLASS=\"BannerTextCompany\">LogicHealth</SPAN></TD></TR><TR><TD CLASS=\"Banner\"><SPAN CLASS=\"BannerTextApplication\">CSSD打印助手</SPAN></TD></TR><TR><TD CLASS=\"Banner\" ALIGN=\"RIGHT\" /></TR></TABLE></TD></TR></TABLE></TD></TR>\r\n");
            builder.Append("<!-- End Banner -->\r\n");
            builder.Append("<!-- Begin Dialog -->\r\n");
            builder.Append("<TR><TD ALIGN=\"LEFT\"><TABLE CELLPADDING=\"2\" CELLSPACING=\"0\" BORDER=\"0\" WIDTH=\"540\"><TR><TD WIDTH=\"496\">\r\n");
            builder.Append("<!-- Begin AppInfo -->\r\n");
            builder.Append("<TABLE><TR><TD COLSPAN=\"3\">&nbsp;</TD></TR><TR><TD><B>名称: </B></TD><TD WIDTH=\"5\"><SPACER TYPE=\"block\" WIDTH=\"10\" /></TD><TD>CSSD打印助手</TD></TR><TR><TD COLSPAN=\"3\">&nbsp;</TD></TR><TR><TD><B>版本: </B></TD><TD WIDTH=\"5\"><SPACER TYPE=\"block\" WIDTH=\"10\" /></TD><TD>").Append(temp1).Append("</TD></TR><TR><TD COLSPAN=\"3\">&nbsp;</TD></TR><TR><TD><B>发行者: </B></TD><TD WIDTH=\"5\"><SPACER TYPE=\"block\" WIDTH=\"10\" /></TD><TD>LogicHealth</TD></TR><tr><td colspan=\"3\">&nbsp;</td></tr></TABLE>\r\n");
            builder.Append("<!-- End AppInfo -->\r\n");
            builder.Append("<!-- Begin Prerequisites -->\r\n");
            builder.Append("<TABLE ID=\"BootstrapperSection\" BORDER=\"0\"><TR><TD COLSPAN=\"2\">以下系统必备组件是必需的: </TD></TR><TR><TD WIDTH=\"10\">&nbsp;</TD><TD><UL>\r\n");
            builder.Append("</UL></TD></TR><TR><TD COLSPAN=\"2\">\r\n");
            builder.Append("如果已经安装了这些组件，您可以立即<SPAN CLASS=\"JustThisApp\"><A HREF=\"LogicHealth_Devops_PrintSetup.exe\">启动</A></SPAN>该应用程序。否则，请单击下面的按钮，安装系统必备组件并运行该应用程序。\r\n");
            builder.Append("</TD></TR><TR><TD COLSPAN=\"2\">&nbsp;</TD></TR></TABLE>\r\n");
            builder.Append("<!-- End Prerequisites -->\r\n");
            builder.Append("</TD></TR></TABLE>\r\n");
            builder.Append("<!-- Begin Buttons -->\r\n");
            builder.Append("<TR><TD ALIGN=\"LEFT\"><TABLE CELLPADDING=\"2\" CELLSPACING=\"0\" BORDER=\"0\" WIDTH=\"540\" STYLE=\"cursor:hand\" ONCLICK=\"window.navigate(InstallButton.href)\"><TR><TD ALIGN=\"LEFT\"><TABLE CELLPADDING=\"1\" BGCOLOR=\"#333333\" CELLSPACING=\"0\" BORDER=\"0\"><TR><TD><TABLE CELLPADDING=\"1\" BGCOLOR=\"#cecece\" CELLSPACING=\"0\" BORDER=\"0\"><TR><TD><TABLE CELLPADDING=\"1\" BGCOLOR=\"#efefef\" CELLSPACING=\"0\" BORDER=\"0\"><TR><TD WIDTH=\"20\"><SPACER TYPE=\"block\" WIDTH=\"20\" HEIGHT=\"1\" /></TD><TD><A ID=\"InstallButton\" HREF=\"LogicHealth_Devops_PrintSetup.exe\">安装</A></TD><TD width=\"20\"><SPACER TYPE=\"block\" WIDTH=\"20\" HEIGHT=\"1\" /></TD></TR></TABLE></TD></TR></TABLE></TD></TR></TABLE></TD><TD WIDTH=\"15%\" ALIGN=\"right\" /></TR></TABLE></TD></TR>\r\n");
            builder.Append("<!-- End Buttons -->\r\n");
            builder.Append("</TD></TR>\r\n");
            builder.Append("<!-- End Dialog -->\r\n");
            builder.Append("<!-- Spacer Row -->\r\n");
            builder.Append("<TR><TD>&nbsp;</TD></TR>\r\n");
            builder.Append("<TR><TD>\r\n");
            builder.Append("<!-- Begin Footer -->\r\n");
            builder.Append("<TABLE WIDTH=\"100%\" CELLPADDING=\"0\" CELLSPACING=\"0\" BORDER=\"0\" BGCOLOR=\"#ffffff\"><TR><TD HEIGHT=\"5\"><SPACER TYPE=\"block\" HEIGHT=\"5\" /></TD></TR><TR><TD CLASS=\"FooterText\" ALIGN=\"center\"><A HREF=\"https://go.microsoft.com/fwlink/?LinkId=154571\">ClickOnce 和 .NET Framework 资源</A>\r\n");
            builder.Append("</TD></TR><TR><TD HEIGHT=\"5\"><SPACER TYPE=\"block\" HEIGHT=\"5\" /></TD></TR><TR><TD HEIGHT=\"1\" bgcolor=\"#cecece\"><SPACER TYPE=\"block\" HEIGHT=\"1\" /></TD></TR></TABLE>\r\n");
            builder.Append("<!-- End Footer -->\r\n");
            builder.Append("</TD></TR>\r\n");
            builder.Append("</TABLE>\r\n");
            builder.Append("  </BODY>\r\n");
            builder.Append("</HTML>\r\n");
            return builder.ToString();
        }

        internal static string CreateVbsFile(string fullUrl,string winDirectory ) {
            StringBuilder builder = new StringBuilder();
            
            builder.Append("Set objShell = WScript.CreateObject(\"WScript.Shell\" )\r\n");
            builder.Append("u = \"").Append(fullUrl).Append("\"\r\n");
            builder.Append("objShell.Run(\"\"\"").Append(winDirectory).Append("\\System32\\rundll32.exe\"\" \"\"").Append(winDirectory).Append("\\System32\\dfshim.dll\"\",ShOpenVerbApplication \" & u)\r\n");
            builder.Append("Set objShell = Nothing\r\n");

            return builder.ToString();
        }
    }
}
