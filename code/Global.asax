<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        Application.Lock();
        Application["msg"] = "";
        Application["adminOn"] = false;
        Application.UnLock();
        

    }
    
    void Application_End(object sender, EventArgs e) 
    {
       
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
    }

    void Session_End(object sender, EventArgs e) 
    {

    }
       
</script>
