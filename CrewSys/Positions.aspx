<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="Positions.aspx.vb" Inherits="CrewSys.Positions" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header card">
        <div class="card-block">
            <h5 class="m-b-10">RANK</h5>
            <p class="text-muted m-b-10">Manage Ranks</p>
        </div>
    </div>



    <div class="page-body">
        <div class="card">
            <div class="card-block">


                <asp:UpdatePanel ID="upRank" runat="server">
                    <ContentTemplate>

                        <div class="row">
                            <div class="col-sm-6">
                                <asp:Button ID="btnAddNew" runat="server" Text="Add New Rank" CssClass="btn btn-success pull-left" UseSubmitBehavior="False" />
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group row">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-round" placeholder="Search for Rank"></asp:TextBox>
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

                                    <asp:GridView ID="gvRank" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                        <Columns>

                                            <asp:BoundField DataField="RankCode" HeaderText="Rank Code" SortExpression="RankCode" />
                                            <asp:TemplateField HeaderText="Rank" SortExpression="RankDescription">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbRank" runat="server" Text='<%# Bind("RankDescription") %>' CommandName="View" CommandArgument='<%#Eval("RankID")%>' CssClass="text-primary"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="RankSortCode" HeaderText="Rank Sort Code" SortExpression="RankSortCode" />--%>

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
                                            <label class="col-sm-2 col-form-label">Rank Code<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtRankCode" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Rank Code"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Rank<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtRank" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Rank"></asp:TextBox>
                                            </div>
                                        </div>
                                       <%-- <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Rank Sort Code<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtRankSort" runat="server"
                                                    onkeydown="if(event.keyCode<8 || event.keyCode>8 && (event.keyCode<46 || event.keyCode>46) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;"
                                                    required="required" CssClass="form-control form-control-round" placeholder="Rank Sort"></asp:TextBox>
                                            </div>
                                        </div>--%>

                                        <div class="actionbar">
                                            <asp:LinkButton ID="lbBack" runat="server" CssClass="btn btn-success pull-left">Back to Search</asp:LinkButton>
                                            <asp:Button ID="btnAddUpdateRanks" runat="server" Text="Update Rank" CssClass="btn btn-success pull-right" />
                                        </div>

                                    </div>
                                </div>
                            </asp:View>



                            <asp:View ID="vAddNewKeywords" runat="server">
                                <!-- Add Keywords -->
                                <asp:HiddenField ID="hdnMode" runat="server" />
                                <asp:HiddenField ID="hdnID" runat="server" />
                                <asp:HiddenField ID="hdnView" runat="server" />
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
