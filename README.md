# Snow-Task1

BAR GRAPH – CLIENT / SERVER APPLICATION  - Solution

##Idea:
My plan is to create a self-hosted ASP.NET Web API server application and to use AngularJS and Highcharts. Also, since the bars should be refreshed with random values every minute, I would like to use SignalR to use push capability from the server instead of the usual client requesting/checking. AngularJS is based on two-way binding so connecting it with SignalR should be the the best possible way to solve this task. I don’t have any reasons to use self-hosted service except that I’ve never used it before and wanted to test it now.

##Implementation:
Server application development was pretty straightforward. Resolving relative path to save the file was problematic and it seems that for self-hosted services it must be done somewhat differently. 
Proper error handling should be done by using ExceptionFilterAttributes to avoid error handling code duplicating in controllers. 
I have a problem with connecting Highcharts and AngularJS data. After losing too much time I realise that I must simplify my solution, especially since I have no experience with SignalR which could cause extra time loss,and I would need too much time to do it as I planned. Frontend is now implemented using HTML, jQuery and AJAX.

##Running application:
Run ServerApp, it is running on localhost:9000
Open index.html at localhost:9001
If inital file upload is errorless, the chart will update automatically with random values every 60 seconds.

##Conclusion:
It would take me too long to solve this task with technologies I planned to use. I don’t have enough experience with key technologies – SignalR and AngularJS, and connecting them together. But, real-time applications should be definitely done with the “push from server” approach. 
