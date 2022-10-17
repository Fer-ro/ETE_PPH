<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ETE_PPH.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet"/>
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

</head>
<body style="background-color:#3d4c74">   
    

    <style>
        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../Imagenes/ES_121355.gif");
            background-position: center center;
            background-repeat: no-repeat;
            background-color: #e4e4e6;
            z-index: 500 !important;
            opacity: 0.8;
            overflow: hidden;
        }
    </style>

    <br />
    <br />
    <br />

     
    <div class="container">
    <div class="row">
        <div class="col-md-12 min-vh-100 d-flex flex-column justify-content-center">
            <div class="row">
                <div class="col-lg-6 col-md-8 mx-auto">
                    <form id="form1" runat="server">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdateProgress runat="server" ID="PageUpdateProgress" AssociatedUpdatePanelID="UpdatePanel2" DisplayAfter="20" DynamicLayout="true">
                            <ProgressTemplate>

                                <div class="update">
                                </div>

                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    <!-- form card login -->
                    <div class="card rounded shadow shadow-sm">
                        
                        <div class="card-body" style="text-align: center" >
                            <h3 class="mb-0">Acceso</h3>
                            <hr />
                            <br />
                            <form class="form" role="form"  autocomplete="off" id="formLogin" novalidate="" method="POST">
                                <div style="text-align: center">
                                    <div class="form-group">
                                       <h5> <b>
                                            <label for="uname1">Nomina</label></b></h5>
                                        <asp:TextBox ID="loginNomina_" style="text-align: center;"  runat="server" class="form-control form-control-lg rounded-1"></asp:TextBox>
                                        <br />
                                        <h5> <b> <label for="uname1">Password</label></b></h5>
                                        <asp:TextBox ID="TXT_Pass" style="text-align: center;" TextMode="Password" runat="server" class="form-control form-control-lg rounded-1"></asp:TextBox>

                                        <div class="invalid-feedback">Oops, you missed this one.</div>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                       <ContentTemplate>
                                                                            <asp:Button ID="BTN_Entrar" style="text-align: center" OnClick="BTN_Entrar_Click" class="btn btn-lg btn-success btn-block" runat="server" Text="Entrar" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </form>
                        </div>
                        <!--/card-block-->
                    </div>
                    <!-- /form card login -->
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
              <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="1000"></asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>
                      </form>
                </div>


            </div>
            <!--/row-->

        </div>
        <!--/col-->
    </div>
    <!--/row-->
</div>
<!--/container-->
    
   
  
                    
                    

                    
                  
                
    
</body>
</html>
