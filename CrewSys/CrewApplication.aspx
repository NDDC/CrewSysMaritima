<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="CrewApplication.aspx.vb" Inherits="CrewSys.CrewApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="css/Form-Wizard.css" rel="stylesheet" />



    <%--    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>--%>


    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= ddlRank.ClientID%>").selectpicker();
            $("#<%= ddlYear.ClientID%>").selectpicker();
            $("#<%= ddlCivilStatus.ClientID%>").selectpicker();
            $("#<%= ddlFlagstate.ClientID%>").selectpicker();
            $("#<%= ddlTrainingCenter.ClientID%>").selectpicker();
            $("#<%= ddlDocCode.ClientID%>").selectpicker();
            $("#<%= ddlRelationship.ClientID%>").selectpicker();
            $("#<%= ddlRank2.ClientID%>").selectpicker();
            $("#<%= ddlFlag.ClientID%>").selectpicker();
            $("#<%= ddlVesselType.ClientID%>").selectpicker();
            $("#<%= ddlFlagstate.ClientID%>").selectpicker();

            $(".selectpicker").selectpicker();
        });

        function pageLoad(sender, args) {
            RefreshDDL()


            $('[id*=GenderMF]').bootstrapToggle({
                on: 'FEMALE',
                off: 'MALE',
                onstyle: 'primary',
                offstyle: 'success'
            });
        }
    </script>

   

    <script>
    
        $(function () {
            $("#<%= txtExStartDate.ClientID%>").datepicker({
                changeYear: true,
                changeMonth: true,
                showMonthAfterYear: true,
                yearRange: '1960:+0',
                dateFormat: 'dd-M-yy',

                minDate: '-60Y',
                maxDate: '+0D',
            })
        });

        $(function () {
            $("#<%= txtExStartDate.ClientID%>").change(function () {
                var exstart = $("#<%= txtExStartDate.ClientID%>").val();
                $("#<%=txtExEndDate.ClientID%>").datepicker('destroy');
                $("#<%= txtExEndDate.ClientID%>").datepicker({
                    changeYear: true,
                    changeMonth: true,
                    showMonthAfterYear: true,
                    // yearRange: '-60Y:+15',
                    dateFormat: 'dd-M-yy',

                    minDate: new Date(exstart),
                    maxDate: '+15Y',
                })
            });
        });

        $(function () {
            $("#<%= txtIDate.ClientID%>").datepicker({
                changeYear: true,
                changeMonth: true,
                showMonthAfterYear: true,
                yearRange: '-60Y:+0',
                dateFormat: 'dd-M-yy',

                minDate: '-60Y',
                maxDate: '+0D',
            })
        });

        $(function () {
            $("#<%= txtIDate.ClientID%>").change(function () {
                var istart = $("#<%= txtIDate.ClientID%>").val();
                $("#<%=txtExdate.ClientID%>").datepicker('destroy');
                $("#<%= txtExdate.ClientID%>").datepicker({
                    changeYear: true,
                    changeMonth: true,
                    showMonthAfterYear: true,
                    // yearRange: '-60Y:+15',
                    dateFormat: 'dd-M-yy',

                    minDate: new Date(istart),
                    maxDate: '+15Y',
                })
            });
        });
     
    </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:UpdatePanel ID="upVessels" runat="server">
        <ContentTemplate>

            <div class="page-header card">
                <div class="card-block">
                    <div class="form-group row">
                        <div class="col-sm-4">
                            <h5 class="m-b-10">CREW APPLICATION</h5>
                            <p class="text-muted m-b-10">New Applicant</p>
                        </div>

                        <div class="col-sm-8 pull-right">
                            <div id="smartwizard" class="sw-main sw-theme-dots pull-right">
                                <ul class="nav nav-tabs step-anchor">
                                    <li class="nav-item active" runat="server" id="Step1">
                                        <a href="#" class="nav-link">Crew Profile<br />
                                            <small>Step 1</small></a></li>
                                    <li class="nav-item" runat="server" id="Step2">
                                        <a href="#" class="nav-link">Family<br />
                                            <small>Step 2</small></a></li>
                                    <li class="nav-item" runat="server" id="Step3">
                                        <a href="#" class="nav-link">Sea Service<br />
                                            <small>Step 3</small></a></li>
                                    <li class="nav-item" runat="server" id="Step4">
                                        <a href="#" class="nav-link">Crew Documents<br />
                                            <small>Step 4</small></a></li>
                                </ul>

                            </div>
                        </div>
                    </div>
                </div>
            </div>




            <div class="page-body">
                <div class="card">
                    <div class="card-block">

                        <asp:MultiView ID="mvApplicants" runat="server">



                            <asp:View ID="vProfile" runat="server">

                                <div class="row simple-cards users-card">
                                    <div class="col-md-12 col-xl-12">
                                        <div class="card user-card">
                                            <div class="card-header-img">

                                                <asp:Image ID="CrewImage" Width="150px" Height="150px" runat="server"
                                                    AlternateText="Photo"
                                                    ImageAlign="Middle"
                                                    ImageUrl="PhotoPic/cmale.png" CssClass="img-circle m-b" /></center>

                                            <asp:HiddenField ID="hdnPhotoSource" runat="server"></asp:HiddenField>

                                                <asp:LinkButton ID="UpCrewPhoto" data-toggle="modal" data-target="#UpPhoto" CssClass="btn btn-success" runat="server">Upload Photo</asp:LinkButton>
                                                <div class="form-group">
                                                    <font color="red">
                                        <asp:Label ID="lblWarning" runat="server" Text=""></asp:Label>
                                    </font>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>





                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">Crew Number</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtCrewNo" runat="server" CssClass="form-control form-control-round" placeholder="Crew Number" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">Password</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtPass" runat="server" CssClass="form-control form-control-round" placeholder="Password" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">Rank</label>
                                    <div class="col-sm-10">
                                        <asp:DropDownList ID="ddlRank" runat="server" required="required" CssClass="form-control" data-live-search="true"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">First Name</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control form-control-round" placeholder="First Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">Middle Initial/Name</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control form-control-round" placeholder="Middle Initial/Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">Last Name</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control form-control-round" placeholder="Last Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">Gender<span class="required">*</span></label>
                                    <div class="col-sm-10">
                                        <input id="GenderMF" type="checkbox" runat="server" />
                                        <asp:HiddenField ID="hdnGender" runat="server" />
                                    </div>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="form-group row">
                                            <label class="col-sm-2 col-form-label" for="txtBirthdate">Date of Birth<span class="required">*</span></label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtBirthdate" runat="server" required="required" CssClass="form-control form-control-round" placeholder="MM/DD/YYYY" AutoPostBack="true" OnTextChanged="txtBirthdate_TextChanged"></asp:TextBox>
                                                <ajax:CalendarExtender ID="ceBDate" PopupButtonID="imgPopup" runat="server" TargetControlID="txtBirthdate" Format="MM/dd/yyyy"></ajax:CalendarExtender>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                                    InputDirection="LefttoRight" TargetControlID="txtBirthdate" />
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">Birthplace</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtBirthplace" runat="server" CssClass="form-control form-control-round" placeholder="Birthplace"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">Address 1</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtPrimaryAddress" runat="server" CssClass="form-control form-control-round" placeholder="Primary Address"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">Address 2</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtSAddress" runat="server" CssClass="form-control form-control-round" placeholder="Secondary Address"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">Contact Number</label>
                                    <div class="col-sm-10">
                                        <%-- <asp:TextBox ID="txtContact" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Contact Number"
                                                onkeydown="if(event.keyCode<32 || event.keyCode>32 && (event.keyCode<40 || event.keyCode>41) && (event.keyCode<43 || event.keyCode>47) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;">
                                            </asp:TextBox>--%>
                                        <asp:TextBox ID="txtContact" runat="server" CssClass="form-control form-control-round" placeholder="Contact Number"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">Email Address</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtEAdd" runat="server" CssClass="form-control form-control-round" placeholder="Email Address"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEAdd" ErrorMessage="Invalid Email Address!"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="text-danger"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">Civil Status</label>
                                    <div class="col-sm-10">
                                        <asp:DropDownList ID="ddlCivilStatus" runat="server" required="required" CssClass="form-control" placeholder="Select Civil Status" data-live-search="true"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">School</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtSchool" runat="server" CssClass="form-control form-control-round" placeholder="School"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">Course</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtCourse" runat="server" CssClass="form-control form-control-round" placeholder="Course"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">Year Graduated</label>
                                    <div class="col-sm-10">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control" data-live-search="true"></asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">SSS Number<span class="required">*</span></label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtSSS" runat="server" required="required" CssClass="form-control form-control-round" placeholder="SSS Number"></asp:TextBox>
                                        <ajaxToolkit:MaskedEditExtender ID="meeSSS" runat="server" Enabled="True" Mask="99-99999999" MaskType="Number"
                                            InputDirection="LefttoRight" TargetControlID="txtSSS" />
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">Philhealth Number<span class="required">*</span></label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtPhilHealth" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Philhealth Number"></asp:TextBox>
                                        <ajaxToolkit:MaskedEditExtender ID="meePhilHealth" runat="server" Enabled="True" Mask="99-99999999" MaskType="Number"
                                            InputDirection="LefttoRight" TargetControlID="txtPhilHealth" />
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">PAGIBIG Number<span class="required">*</span></label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtPagibig" runat="server" required="required" CssClass="form-control form-control-round" placeholder="PAGIBIG Number"></asp:TextBox>
                                        <ajaxToolkit:MaskedEditExtender ID="meePagibig" runat="server" Enabled="True" Mask="99-9999999999" MaskType="Number"
                                            InputDirection="LefttoRight" TargetControlID="txtPagibig" />
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">TIN Number<span class="required">*</span></label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtTIN" runat="server" required="required" CssClass="form-control form-control-round" placeholder="TIN Number"></asp:TextBox>
                                        <ajaxToolkit:MaskedEditExtender ID="meeTIN" runat="server" Enabled="True" Mask="999-999-999" MaskType="Number"
                                            InputDirection="LefttoRight" TargetControlID="txtTIN" />
                                    </div>
                                </div>
<%--                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">Licence Number<span class="required">*</span></label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtLicense" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Licence Number"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">SIRB<span class="required">*</span></label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtSirb" runat="server" required="required" CssClass="form-control form-control-round" placeholder="SIRB"></asp:TextBox>
                                    </div>
                                </div>--%>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">SRC<span class="required">*</span></label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtSRC" runat="server" required="required" CssClass="form-control form-control-round" placeholder="SRC"></asp:TextBox>
                                    </div>
                                </div>

                                <asp:Button ID="btnNextFam" runat="server" Text="SAVE and CONTINUE" CssClass="btn btn-success pull-right" UseSubmitBehavior="false" />
                                <asp:HiddenField ID="hdnCrewNo" runat="server" />

                            </asp:View>



                            <asp:View ID="vFamily" runat="server">

                                <div class="actionBar">
                                    <%--    <asp:Button ID="btnAddFam" runat="server" Text="Add Family Member" class="btn btn-success" data-toggle="modal" data-target="#FamModal" />--%>
                                    <button type="button" name="btnAddFam" class="btn btn-success pull-right" data-toggle="modal" data-target="#FamModal">Add Family Member</button>
                                </div>
                                <br />
                                <br />
                                <br />


                                <div class="table-responsive">

                                    <asp:GridView ID="gdFamList" runat="server" AllowPaging="True" AllowSorting="True" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" AutoGenerateColumns="False" Width="100%" PageSize="30" HeaderStyle-CssClass="headings" EmptyDataText="There are no data records to display.">

                                        <Columns>
                                            <asp:BoundField DataField="AllotteeName" HeaderText="Allottee Name" SortExpression="AllotteeName" />
                                            <asp:BoundField DataField="Relationship" HeaderText="Relationship" SortExpression="Relationship" />
                                            <asp:BoundField DataField="BankAccount" HeaderText="Bank Account" SortExpression="BankAccount" />
                                            <asp:BoundField DataField="Branch" HeaderText="Branch" SortExpression="Branch" />
                                            <asp:BoundField DataField="ZipCode" HeaderText="Zip Code" SortExpression="ZipCode" />
                                            <asp:BoundField DataField="ContactNo" HeaderText="Contact No" SortExpression="ContactNo" />
                                        </Columns>

                                        <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                        <HeaderStyle ForeColor="Blue" />
                                    </asp:GridView>
                                </div>


                                <div class="actionbar">
                                     <asp:LinkButton ID="lbPrevProfile" runat="server" CssClass="btn btn-success pull-left">PREVIOUS</asp:LinkButton>
                                    <asp:LinkButton ID="lbNextSea" runat="server" CssClass="btn btn-success pull-right">NEXT</asp:LinkButton>
                                </div>

                            </asp:View>



                            <asp:View ID="vSeaService" runat="server">

                                <div class="actionBar">
                                    <button type="button" name="btnAddExSeaservice" class="btn btn-success pull-right" data-toggle="modal" data-target="#ESSModal">Add External Sea Service</button>
                                </div>
                                <br />
                                <br />
                                <br />


                                <div class="table-responsive">


                                    <asp:GridView ID="gdSeaService" runat="server" AllowPaging="True" AllowSorting="True" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" AutoGenerateColumns="False" Width="100%" HeaderStyle-CssClass="headings" PageSize="30" EmptyDataText="There are no data records to display.">

                                        <Columns>
                                            <asp:BoundField DataField="RankCode" HeaderText="Rank" SortExpression="RankSortCode" />
                                            <asp:BoundField DataField="VesselName" HeaderText="Vessel Name" SortExpression="VesselName" />
                                            <asp:BoundField DataField="VesselType" HeaderText="Vessel Type" SortExpression="VesselType" />
                                            <asp:BoundField DataField="GRT" HeaderText="GRT" SortExpression="GRT" />
                                            <asp:BoundField DataField="EngineType" HeaderText="Engine Type" SortExpression="EngineType" />
                                            <asp:BoundField DataField="StartDate" HeaderText="Start Date" DataFormatString="{0:MM/dd/yyyy }" HtmlEncode="false" SortExpression="StartDate" />
                                            <asp:BoundField DataField="EndDate" HeaderText="End Date" DataFormatString="{0:MM/dd/yyyy }" HtmlEncode="false" SortExpression="EndDate" />
                                        </Columns>

                                        <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                        <HeaderStyle ForeColor="Blue" />

                                    </asp:GridView>

                                </div>

                                <div class="actionbar">
                                    <asp:LinkButton ID="lbBackFam" runat="server" CssClass="btn btn-success pull-left">PREVIOUS</asp:LinkButton>
                                    <asp:LinkButton ID="lbNextDocs" runat="server" CssClass="btn btn-success pull-right">NEXT</asp:LinkButton>
                                </div>

                            </asp:View>



                            <asp:View ID="vDocs" runat="server">

                                <div class="actionBar">
                                    <button type="button" name="btnAddDoc" class="btn btn-success pull-right" data-toggle="modal" data-target="#CrewDoc">Add Crew Documents</button>
                                </div>
                                <br />
                                <br />
                                <br />

                                <div class="table-responsive">

                                    <asp:GridView ID="gdDocs" runat="server" AllowPaging="True" AllowSorting="True" CssClass="table table-striped table-bordered nowrap dataTable no-footer dtr-inline collapsed" AutoGenerateColumns="False" Width="100%" HeaderStyle-CssClass="headings" PageSize="30" EmptyDataText="There are no data records to display.">

                                        <Columns>
                                            <asp:BoundField DataField="DocTitle" HeaderText="Document Title" SortExpression="DocTitle" />
                                            <asp:BoundField DataField="DocNo" HeaderText="Document Number" SortExpression="DocNo" />
                                            <asp:BoundField DataField="IssuedDate" HeaderText="IssuedDate" DataFormatString="{0:MM/dd/yyyy }" HtmlEncode="false" SortExpression="IssuedDate" />
                                            <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date" DataFormatString="{0:MM/dd/yyyy }" HtmlEncode="false" SortExpression="ExpiryDate" />
                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
                                        </Columns>

                                        <PagerStyle CssClass="GridPager" HorizontalAlign="Center" />
                                        <HeaderStyle ForeColor="Blue" />

                                    </asp:GridView>

                                </div>

                                <div class="actionbar">
                                    <asp:LinkButton ID="lbBackSea" runat="server" Text="PREVIOUS" CssClass="btn btn-success pull-left" />
                                    <asp:LinkButton ID="lbDone" runat="server" Text="NEXT" CssClass="btn btn-success pull-right" />
                                </div>

                            </asp:View>



                        </asp:MultiView>

                    </div>
                </div>
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="lbUploadPhoto" />
            <asp:PostBackTrigger ControlID="btnNextFam" />
            <asp:PostBackTrigger ControlID="btnAddAllottee" />
            <asp:PostBackTrigger ControlID="btnSaveESS" />
            <asp:PostBackTrigger ControlID="btnSaveDoc" />
        </Triggers>
    </asp:UpdatePanel>


    <!-- Modal -->
    <div class="modal fade" id="UpPhoto" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Upload Photo</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Upload Photo</label>
                        <div class="col-sm-10">
                            <asp:FileUpload ID="fuPhoto" runat="server"></asp:FileUpload>
                            <asp:RegularExpressionValidator ControlToValidate="fuPhoto" ValidationExpression="^.*\.(png|PNG|jpg|jpeg|JPG|JPEG)$" runat="server" ErrorMessage="Upload valid Picture Formats!" CssClass="text-danger" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                    <asp:LinkButton ID="lbUploadPhoto" runat="server" CssClass="btn btn-success waves-effect waves-light">SAVE</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <!--End of Modal-->


    <!-- Modal -->
    <div class="modal fade" id="FamModal" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Family</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Last Name<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtLFName" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Last Name"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">First Name<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtFFName" runat="server" required="required" CssClass="form-control form-control-round" placeholder="First Name"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Middle Name<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtMFName" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Middle Name"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Address 1<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtFPAddress" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Address 1"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Address 2<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtFSAddress" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Address 2"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Relationship<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="ddlRelationship" runat="server" required="required" CssClass="form-control rounded" placeholder="Select Relationship" data-live-search="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Bank Account<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtBankAccount" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Bank Account"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Branch<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtBranch" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Branch"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Zip Code<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtZipCode" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Zip Code"></asp:TextBox>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Enabled="True" Mask="9999" MaskType="Number"
                                InputDirection="LefttoRight" TargetControlID="txtZipCode" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Contact Number<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <%--<asp:TextBox ID="txtContactNo" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Contact Number"
                                                                onkeydown="if(event.keyCode<32 || event.keyCode>32 && (event.keyCode<40 || event.keyCode>41) && (event.keyCode<43 || event.keyCode>47) && (event.keyCode<48 || event.keyCode>57))event.returnValue=false;">
                                                            </asp:TextBox>--%>
                            <asp:TextBox ID="txtContactNo" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Contact Number"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                    <asp:Button ID="btnAddAllottee" runat="server" Text="Save Allottee" CssClass="btn btn-success waves-effect waves-light pull-right" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
    </div>
    <!--End of Modal-->


    <!-- Modal -->
    <div class="modal fade" id="ESSModal" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Sea Service</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Rank</label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="ddlRank2" runat="server" required="required" CssClass="form-control" placeholder="Select Rank" data-live-search="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Joining Port</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtJoiningPort" runat="server" CssClass="form-control form-control-round" placeholder="Joining Port"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Embarking Port</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtEmbarkingPort" runat="server" CssClass="form-control form-control-round" placeholder="Embarking Port"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Ex Vessel Name</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtExVesselName" runat="server" CssClass="form-control form-control-round" placeholder="Ex Vessel Name"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Call Sign</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtCallsign" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Call Sign"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">GRT</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtGRT" runat="server" CssClass="form-control form-control-round" placeholder="GRT"
                                onkeydown="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Flag</label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="ddlFlag" runat="server" CssClass="form-control" data-live-search="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Vessel Type</label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="ddlVesselType" runat="server" CssClass="form-control rounded" data-live-search="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Engine Type<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtEngineType" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Engine Type"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Start Date<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtExStartDate" runat="server" required="required" CssClass="form-control form-control-round" placeholder="Start Date"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">End Date<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtExEndDate" runat="server" required="required" CssClass="form-control form-control-round" placeholder="End Date"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                    <asp:Button ID="btnSaveESS" runat="server" Text="Save Allottee" CssClass="btn btn-success waves-effect waves-light pull-right" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
    </div>
    <!--End of Modal-->


    <!-- Modal -->
    <div class="modal fade" id="CrewDoc" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Crew Documents</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Flagstate<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="ddlFlagstate" runat="server" CssClass="form-control" placeholder="Select Flagstate" data-live-search="true"></asp:DropDownList>
                            <asp:Label ID="lblFlagst" runat="server" Text="For Flagstate and Travel" CssClass="text-text-info"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Training Center<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="ddlTrainingCenter" runat="server" CssClass="form-control" placeholder="Select Training Center" data-live-search="true"></asp:DropDownList>
                            <asp:Label ID="lblTrainingCe" runat="server" Text="For Training" CssClass="text-text-info"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Document Title<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="ddlDocCode" runat="server" required="required" CssClass="form-control" placeholder="Select Document" data-live-search="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Upload Document<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:FileUpload ID="fuPath" runat="server"></asp:FileUpload>
                            <asp:RegularExpressionValidator ControlToValidate="fuPath" ValidationExpression="^.*\.(pdf|PDF|jpg|jpeg|JPG|JPEG|png|PNG)$" runat="server" ErrorMessage="Upload ONLY pdf, jpg, png formats!" CssClass="text-danger" />
                        </div>
                        <asp:Label ID="lblWarning2" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Document Number</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtDocNo" runat="server" CssClass="form-control form-control-round" placeholder="Document Number"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Issued Date<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtIDate" runat="server" required="required" CssClass="form-control form-control-round" ReadOnly="true" placeholder="Select Issued Date"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Expiry Date<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtExdate" runat="server" CssClass="form-control form-control-round" ReadOnly="true" placeholder="Select Expiry Date"></asp:TextBox>
                            <asp:CheckBox ID="chkNoExpiry" runat="server" Text="No Expiration" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Remarks<span class="required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control rounded" placeholder="Remarks"></asp:TextBox>
                        </div>
                    </div>
                    <asp:HiddenField ID="hdnPath" runat="server" />
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-default waves-effect " data-dismiss="modal">Close</button>
                    <asp:Button ID="btnSaveDoc" runat="server" Text="Save Crew Document" CssClass="btn btn-success waves-effect waves-light pull-right" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
    </div>
    <!--End of Modal-->
</asp:Content>
