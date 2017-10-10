var isFileUploaded = false;

function DrawChart(series) {

    $('#container').highcharts({

        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: 1, 
            plotShadow: false
        },
        title: {
            text: 'Bars data'
        },
        series: series
    });
}

function UploadFile(file)
{
    // Make Ajax request with the contentType = false, and procesDate = false
    $.ajax({
        type: "POST",
        url: "http://localhost:9000/api/file",
        contentType: false,
        processData: false,
        data: file,
        success: function (Result) {

            if (Result.Status===200) {
                for (var i = 0; i < Result.Data.length; i++) {
                    $("#result").append("<div>Name:" + Result.Data[i].Name + ", Color: " + Result.Data[i].Color + ", Value: " + Result.Data[i].Value + "</div>");
                }

                var data = [];
                for (var i in Result.Data) {
                    var serie = { type: 'column', name: Result.Data[i].Name, color: Result.Data[i].Color, data: [Result.Data[i].Value] }
                    data.push(serie);
                }

                DrawChart(data);
                isFileUploaded = true;
            }
            else {
                isFileUploaded = false;
                $("#result").append(Result.Message);
            }
        },

        error: function (err) {
            $("#result").append("Error occured!");
        }
    });
}

function GetRandomData()
{
    $("#result").empty();

    $.ajax({
        type: "GET",
        url: "http://localhost:9000/api/file/random",
        contentType: false,
        processData: false,
        success: function (Result) {

            if (Result.Status===200) {
                for (var i = 0; i < Result.Data.length; i++) {
                    $("#result").append("<div>Name:" + Result.Data[i].Name + ", Color: " + Result.Data[i].Color + ", Value: " + Result.Data[i].Value + "</div>");
                }

                var data = [];
                for (var i in Result.Data) {
                    var serie = { type: 'column', name: Result.Data[i].Name, color: Result.Data[i].Color, data: [Result.Data[i].Value] }
                    data.push(serie);
                }

                DrawChart(data);
            }
        },

        error: function (err) {
            $("#result").append("Error occured!");
        }
    });
}

$(document).ready(function () {

        $('#btnUploadFile').on('click', function () {
            $("#result").empty();

            var data = new FormData();
            var files = $("#fileUpload").get(0).files;
            // Add the uploaded content to the form data collection
            if (files.length > 0) {
                data.append("UploadedFile", files[0]);
            }

            UploadFile(data);

        });

        $('#btnRandom').on('click', function () {
            $("#result").empty();
            GetRandomData();            
        });

        
        setInterval(function(){
            if (isFileUploaded===true)
            {
                GetRandomData();
            }
        }, 60000);
                
    });