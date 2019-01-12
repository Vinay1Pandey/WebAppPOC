<%@ Page Title="Disputes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Disputes.aspx.cs" Inherits="BSNL.Disputes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <div class="col-lg-12">
            <h1 class="page-header">Dispute Details</h1>
        </div>
        <!-- /.col-lg-12 -->

    </div>
    <div class="row">
        <div class="col-lg-12">

            <div class="panel panel-default">

                <div class="panel-heading">
                    Disputes
                </div>
                <!-- /.panel-heading -->
                <div class="panel-body">

                    <div class="dataTable_wrapper table-responsive">
                        <asp:GridView ID="gvDisputes" runat="server" DataKeyNames="CustomerID" OnPageIndexChanging="OnPageIndexChanging" PageSize="10"
                            CssClass="table table-striped table-bordered table-hover" AllowPaging="True" OnRowEditing="edit" ShowFooter="false" AutoGenerateColumns="False"
                            OnRowDeleting="delete"
                            OnRowCancelingEdit="canceledit"
                            OnRowUpdating="update" EmptyDataText="No records to show" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="CustomerID" ReadOnly="true" HeaderText="Customer ID" />
                                <asp:BoundField DataField="RequestDate" HeaderText="Request Date" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="RequestType" HeaderText="Request Type" />
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ButtonEdit" runat="server" CssClass="center-block" ImageUrl="~/Images/22.png" CommandName="Edit" CausesValidation="false" formnovalidate />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:ImageButton ImageUrl="~/Images/yes.png" Width="25px" Height="25px" ID="ButtonUpdate" runat="server" CommandName="Update" CausesValidation="false" formnovalidate />
                                        <asp:ImageButton ImageUrl="~/Images/cross-red.png" Width="25px" Height="25px" ID="ButtonCancel" runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" formnovalidate />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/images/trash.png" HeaderText="" />--%>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="DeleteButton" runat="server" CssClass="center-block" ImageUrl="~/Images/11.png"
                                            CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this Account?');"
                                            AlternateText="Delete" CausesValidation="false" formnovalidate />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>


                            <PagerSettings Mode="NumericFirstLast" NextPageImageUrl="~/Images/nextPage.png" PageButtonCount="5" />

                        </asp:GridView>


                    </div>
                    <!-- /.table-responsive -->
                    <asp:Button ID="btnAddNewRow" runat="server" CssClass="btn btn-success pull-right" Text="Add More" PostBackUrl="~/AddDisputes.aspx" />

                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
    </div>
</asp:Content>
