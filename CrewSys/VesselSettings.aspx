<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="VesselSettings.aspx.vb" Inherits="CrewSys.VesselSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= ddlChoose.ClientID%>").selectpicker();

            $(".selectpicker").selectpicker();
            $('.multipleSelect').fastselect();
        });

        function RefreshDDL() {
            $("#<%= ddlChoose.ClientID%>").selectpicker();
        }
        $(function () {
            RefreshDDL()
        });
        function pageLoad(sender, args) {
            RefreshDDL()
        }
       
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="page-header card">
        <div class="card-block">
            <h5 class="m-b-10">VESSEL TYPE & CBA</h5>
            <p class="text-muted m-b-10">Manage Vessel Type and CBA</p>
        </div>
    </div>



    <div class="page-body">
        <div class="card">
            <div class="card-block">


                <asp:UpdatePanel ID="upReason" runat="server">
                    <ContentTemplate>


                        <div class="row">
                            <div class="col-sm-6">
                                <asp:Button ID="btnAddNew" runat="server" Text="Add New Vessel Type or CBA" CssClass="btn btn-success pull-left" UseSubmitBehavior="False" />
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group row">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-round" placeholder="Search for Vessel Type or CBA"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <button id="btnGo1" type="submit" class="input-group-addon search-btn" runat="server">
                                                <i class="ti-search"></i>
                                            </button>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>



                        <asp:MultiView ID="MultiView1" runat="server">

                            <asp:View ID="vViewKewords" runat="server">

                                <div class="table-responsive">

                                    <asp:GridView ID="gvTC" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Vessel Type or CBA" SortExpression="LookUpDescription">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbDesc" runat="server" Text='<%# Bind("LookUpDescription") %>' CommandName="View" CommandArgument='<%#Eval("GenericLookUpID")%>' CssClass="text-primary"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbDelete" runat="server" Text="DELETE" CommandName="DeleteReason" CommandArgument='<%#Eval("GenericLookUpID")%>' CssClass="btn btn-warning"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>

                                        <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                        <HeaderStyle ForeColor="Blue" />

                                    </asp:GridView>

                                </div>

                            </asp:View>



                            <asp:View ID="vUpdateKeywords" runat="server">
                                <div class="panel panel-default">
                                    <header class="panel-heading bg-primary">
                                        <asp:Label ID="lblHead" runat="server" Text="Label"></asp:Label>
                                    </header>
                                    <div class="panel-body">

                                        <br />
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Vessel Type or CBA?<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:DropDownList ID="ddlChoose" runat="server" CssClass="form-control selectpicker pull-right" data-live-search="true">
                                                    <asp:ListItem Text="Vessel Type" Value="VT"></asp:ListItem>
                                                    <asp:ListItem Text="CBA" Value="CB"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Vessel Type or CBA<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtSignOffReason" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Vessel Type or CBA"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="actionbar">
                                            <asp:LinkButton ID="lbBack" runat="server" CssClass="btn btn-success pull-left">Back to Search</asp:LinkButton>
                                            <asp:Button ID="btnAddUpdateReason" runat="server" Text="Update" CssClass="btn btn-success pull-right" />
                                        </div>

                                    </div>
                                </div>
                            </asp:View>



                            <asp:View ID="vAddNewKeywords" runat="server">
                                <!-- Add Keywords -->
                                <asp:HiddenField ID="hdnMode" runat="server" />
                                <asp:HiddenField ID="hdnID" runat="server" />
                                <asp:HiddenField ID="hdnView" runat="server" />
                                <asp:HiddenField ID="hdnCode" runat="server" />
                            </asp:View>



                            <asp:View ID="vActionNotification" runat="server">
                                <h4>
                                    <asp:Label ID="lblMessage" runat="server" Text=" Record Successfully Saved"></asp:Label></h4>
                                <div class="actionBar">
                                    <asp:Button ID="btnBack2" runat="server" Text="Continue" CssClass="btn btn-success pull-right" />
                                </div>
                            </asp:View>

                        </asp:MultiView>


                    </ContentTemplate>
                </asp:UpdatePanel>


            </div>
        </div>
    </div>

</asp:Content>
