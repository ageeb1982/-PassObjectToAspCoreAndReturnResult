/// <reference path="../lib/jquery/dist/jquery.min.js" />

 

var myResult = "";
$(function () {
    

    $('.newStr').click(function () {
        //جديد نصي
        var obj = {
            id: 15,
            name: "Post By JavaScript Object Test",
          gender:1,
            salary: 30
        };
        
         var myJSON = JSON.stringify(obj);
         
        var myurl = "/api/Person/NewPersonStr";
        AjX(myurl, myJSON, 'POST', ".newStrRes");
         
    });

    $('.SrchById').click(function () {
        //تسلسلي
        var obj = {id:5};

        var myurl = "/api/Person/SrchById";
        AjX(myurl, obj, "GET", ".SrchByIdRes" );

         
    });

    $('.SrchByName').click(function () {
        //بحث بالاسم
        var obj = { name: "omer" }; 

        var myurl = "/api/Person/SrchByName";
         AjX(myurl, obj, "GET",".SrchByNameRes");
         
    });

    $('.SrchBySal').click(function () {
        //راتب
        var obj = { salary:50};

        var myurl = "/api/Person/SrchBySalary";
         AjX(myurl, obj, "GET",".SrchBySalRes" );
         
    });

    $('.SrchBy2Sal').click(function () {
        //راتبين
        var sal1 = 10;
        var sal2 = 50;
        var obj = { salary1: sal1, salary2: sal2 };
        var myurl = "/api/Person/SrchByTwoSalary";
        AjX(myurl, obj, "GET",".SrchBySal2Res" );
       
    });



    function GetList(obj) {

        var myUl = document.createElement("ul");
        $.each(obj, function (index, v1) {
            var liX = document.createElement('li');
            var liText = "";
            if (!isNaN(index)) {
                var Str = "";
                $.each(v1, function (iX, vObj) {
                    Str = Str + iX + ":" + vObj + " ; ";
                });
                Str = "{" + Str + "}";
                liText = document.createTextNode(Str);
            }
            else {
                liText = document.createTextNode(index + ":" + v1 + " ");
            }
            
            
            
            liX.appendChild(liText);
            myUl.appendChild(liX);

        });
        return myUl;
    }


    function AjX(myUrl, myObj, myType,myRes) {
        //var Res =
            $.ajax({
            url: myUrl,
            type: myType, //Get,Post
            contentType: "application/json; charset=utf-8",
             data: myObj,
                success: function (response) {
                    window.console.log(response);
                     
                        var list = GetList(response);
                        $(myRes).html(list); 
                     

            },
                error: function (xhr) {
                    window.console.error(xhr);
                    $(myRes).html(xhr);
            }
        });
        //return Res;
    }
});