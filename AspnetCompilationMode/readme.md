This is a prototype so that we can support the compilation="Never" page directive in an mvc project.

So we have two type of aspx files
- aspx file that has the default compilation mode (RecompilesOnChange.aspx)
- aspx file that has the compilation mode set to never. Default page navigate to it with /.

Every pages has a recompilation control at the button of page that give you the information about recompilation:
- recompilation: how many recompilations occured
- recompilation before restart: how many recompilation there are needed before the application does a recyle.

Here to simulate the test.
1) open the project and run it. 
2) go to the RecompilesOnChange.aspx. The recompilation control will show value 0 for recompilations and 15 for recompilation before restart
3) open te recompilesOnchange.Aspx and added some text to it.
4) refresh the page
5) you will now see that the value of recompilations is 1.

After 15 changes the application will shutdown.

So how can we avoid this by adding a compilationmode and set it to never to a page directive:
1) go to the root of the application
2) check the recompilation normmally it should be 0  or the value of the previous test.
3) add some text to views\Home\index.aspx file and save it
4) navigate the the page and you will see that the recompilations didn't change.


The change is located MyBuildManagerView at line 53. If we cannot find a compile type then we try 
to create the page by calling the BuildManager.CreateInstanceFromVirtualPath method.

Please look at the events logged in the aspnet.mdf located under the app_data folder. The database contains a table aspnet_WebEvent_Events.


