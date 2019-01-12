<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="BSNL.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <div class="col-lg-12">
            <h1 class="page-header">Dashboard</h1>
        </div>
        <!-- /.col-lg-12 -->

    </div>
    <div class="row">
        <div class="col-lg-12">

            <div class="panel panel-default">
                <div class="panel-body">
                    <asp:Label ID="lblShow" runat="server" BackColor="Transparent" ForeColor="Green" Font-Bold="true" Font-Size="Large" CssClass="text-center" Text="Welcome To BSNL"></asp:Label>
                </div>
            </div>
            <div class="col-lg-5"></div>
            <div class="col-lg-2" onload="javascript:HideProgressBar()">
                <asp:Button ID="btnProcess" CssClass="btn btn-danger btn-sm" OnClick="btnProcess_Click" OnClientClick="javascript:ShowProgressBar()" runat="server" Text="Process" />
            </div>
            <div id="dvProgressBar" style="float: left; visibility: hidden;">
                <img src="/Images/progress_bar.gif" />
                Processing, please wait...
            </div>
            <div id="dvShow" runat="server" style="display: block;">
                <img src="/Images/show.gif" />
                Completed!
            </div>
            <br style="clear: both" />
            <div class="col-lg-5"></div>
        </div>
    </div>
    <script type="text/javascript">
        function ShowProgressBar() {
            document.getElementById('dvProgressBar').style.visibility = 'visible';
        }

        function HideProgressBar() {
            document.getElementById('dvProgressBar').style.visibility = "hidden";
        }
    </script>
</asp:Content>
