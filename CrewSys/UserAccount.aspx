<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="UserAccount.aspx.vb" Inherits="CrewSys.UserAccount" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header card">
        <div class="card-block">
            <h5 class="m-b-10">Account Profile</h5>
        </div>
    </div>


    <div class="page-body">


        <div class="row simple-cards users-card">
            <div class="col-md-12 col-xl-12">
                <div class="card user-card">
                    <div class="card-header-img">
                        <asp:Image ID="UserImage" runat="server" Width="200px" Height="200px"
                            AlternateText="Photo"
                            ImageAlign="Middle"
                            ImageUrl="PhotoPic/Users.png" CssClass="img-fluid img-radius" />
                        <asp:HiddenField ID="hdnPhotoSource" runat="server"></asp:HiddenField>
                        <font color="red"><asp:Label ID="lblWarning" runat="server" Text=""></asp:Label></font>



                        <asp:MultiView ID="mvProfile" runat="server">

                            <asp:View ID="vProfileInfo" runat="server">

                                <h4>
                                    <asp:Label ID="lblFullName" runat="server" Text=""></asp:Label></h4>
                                <i class="fa fa-briefcase"></i>
                                Module Access:<h5>
                                    <asp:Label ID="lblModule" runat="server" Font-Bold="true"></asp:Label></h5>
                                <i class="ti-user"></i>
                                User Name:<h6>
                                    <asp:Label ID="lblUserName" runat="server" Font-Bold="true"></asp:Label></h6>
                                <i class="fa fa-email"></i>
                                Email:<h6>
                                    <asp:Label ID="lblEmail" runat="server" Font-Bold="true"></asp:Label></h6>
                                <div>
                                    <asp:LinkButton ID="lbChangePic" runat="server" CssClass="btn btn-primary waves-effect waves-light" data-toggle="modal" data-target="#UpPhoto">Change Photo</asp:LinkButton>
                                    <asp:LinkButton ID="lbChangePass" runat="server" CssClass="btn btn-success waves-effect waves-light"><i class="fa fa-edit"></i>Change Password</asp:LinkButton>
                                </div>

                            </asp:View>

                            <asp:View ID="vEditProfileInfo" runat="server">

                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">New Password:</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtNewPass" runat="server" CssClass="form-control form-control-round" TextMode="Password" placeholder="NEW PASSWORD"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <asp:LinkButton ID="lbUpdatePass" runat="server" CssClass="btn btn-success waves-effect waves-light pull-right"><i class="fa fa-edit"></i>Update Password</asp:LinkButton>
                                    <asp:LinkButton ID="lbCancelUpdate" runat="server" CssClass="btn btn-info waves-effect waves-light pull-left">Cancel Update</asp:LinkButton>
                                </div>

                            </asp:View>

                        </asp:MultiView>
                    </div>

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

                </div>
            </div>


        </div>


    </div>

    <asp:HiddenField ID="hdnMode" runat="server" />
    <asp:HiddenField ID="hdnID" runat="server" />
    <asp:HiddenField ID="hdnPhoto" runat="server" />

</asp:Content>
