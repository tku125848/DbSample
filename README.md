1. ASP.NET CORE 6 RAZOR PAGES
1. 導入 Dapper , Newtonsoft.Json , Microsoft.Data.SqlClient
1. 修改 appsettings.json 的 ConnectionStrings
2. 使用 Azure Portal 用學生免費教育帳號登入  
   * Create App Service Plans (WINDOWS, FREE)
   * Create App Service (.NET CORE 6)，確認一定要有 Application Insigns
   * DOWNLOAD PUBLISH SETTINGS
   * 在 VS 上使用匯入 PUBLISHSETTINGS 方式發行網站
   * ``` SQL
            CREATE TABLE [dbo].[test](
            [sn] [int] NULL,
            [title] [nvarchar](50) NULL,
            [dcrt] [datetime] NULL
            ) ON [PRIMARY];
            
            Insert into test values (1,'t1',getdate()) ;
            Insert into test values (2,'t2',getdate()) ;
    * 設定相關防火牆
    * URL /test?sn=1