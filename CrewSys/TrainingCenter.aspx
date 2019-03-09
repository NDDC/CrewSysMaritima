<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="TrainingCenter.aspx.vb" Inherits="CrewSys.TrainingCenter" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header card">
        <div class="card-block">
            <h5 class="m-b-10">TRAINING CENTER</h5>
            <p class="text-muted m-b-10">Manage Training Center</p>
        </div>
    </div>



    <div class="page-body">
        <div class="card">
            <div class="card-block">


                <asp:UpdatePanel ID="upGrid" runat="server">
                    <ContentTemplate>


                        <div class="row">
                            <div class="col-sm-6">
                                <asp:Button ID="btnAddNew" runat="server" Text="Add New Training Center" CssClass="btn btn-success pull-left" UseSubmitBehavior="False" />
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group row">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-round" placeholder="Search for Training Center"></asp:TextBox>
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

                                    <asp:GridView ID="gvDoc" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" PageSize="30" EmptyDataText="There are no data records to display">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Training Center" SortExpression="TrainingCenter">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbDoc" runat="server" Text='<%# Bind("TrainingCenter") %>' CommandName="View" CommandArgument='<%#Eval("TrainingCenterCode")%>' CssClass="text-primary"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="TrainingCenterCode" HeaderText="Training Center Code" SortExpression="TrainingCenterCode" />
                                            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                            <asp:BoundField DataField="Email" HeaderText="Email Address" SortExpression="Email" />

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
                                            <label class="col-sm-2 col-form-label">Training Center Code</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtTCCode" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Training Center Code" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Training Center</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtTraining" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Training Center"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Address</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtAdd" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Address"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Address 2</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtAdd2" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Address 2"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">City Province Name</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtCity" runat="server" required="required" CssClass="form-control form-control-round" placeholder="City Province Name"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Tel Number</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtTel" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Tel Number"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Fax Number</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtFax" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Fax Number"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Contact Person</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtContact" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Contact Person"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label">Email Address</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-round" placeholder="Email Address"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="actionbar">
                                            <asp:LinkButton ID="lbBack" runat="server" CssClass="btn btn-success pull-left">Back to Search</asp:LinkButton>
                                            <asp:Button ID="btnAddUpdateDocs" runat="server" Text="Update Training Center" CssClass="btn btn-success pull-right" />
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
