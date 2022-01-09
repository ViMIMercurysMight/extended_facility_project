/*
window.onload = _ => {

    axios
        .get('/Facility/GetCountOfPages')
        .then(response => alert("COUNT OG PAGES" + response.data ) );


    axios
        .get('/Facility/GetPageItemJson')
        .then(response => alert("PAGE ITEM JSON" + response.data ) );


    axios
        .get("/Facility/GetFacilityStatuseJson")
        .then(response => alert("FACILITY STATUSES" + response.data ));


    axios
        .get('/Facility/GetCountOfPages')
        .then(response => alert(response.data + " PAGES ") );


    axios
        .get('/Facility/GetPageItemJson', {
            params: {
                page: page
            }
        }).then( "FACILITY GET PAGE ITEM JSON ");


    axios({
        method: "DELETE",
        url: "/Facility/Delete/",

        params: {
            id: id
        }
    }).then(_ => { alert("DELETE QUERY")    });



    axios({
        method: "PUT",
        url: "/Facility/Update/",


        data: {
            ...updatedItem
        }
    }).then(_ => alert("PUT QUERY"));




    axios({
        method: "POST",
        url: "/Facility/Create/",

        data: {
            ...data
        }
    }).then(_ => {
        alert("POST QUERY");
    });

};

*/