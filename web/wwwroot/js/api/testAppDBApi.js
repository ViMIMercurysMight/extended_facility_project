

export default class TestDbAPI {

   static Facility = [
        {},
        {},
        {},
        {},
        {},
    ];

    static Patient = [
        {},
        {},
        {},
        {},
        {}
    ];


   static FacilityStatus = [
        { Id: 1, },
        { Id: 2, },
        { Id: 3, }
    ];


    static getRange(start, end, arr) {
        return this.arr.slice(
            this.arr.indexOf(this.arr[perPage * currentPage]),
            this.arr.indexOf(this.arr[perPage * currentPage + perPage]));
    }


    static updateData(id, arr, obj) {
        const item = arr.find(elem => elem.Id == id);
        if (item) 
            arr[arr.findIndex(elem => elem.Id == id)] = obj;
        
    }


    static removeData(id, arr) {
        const item = arr.find(elem => elem.Id == id);
        if (item) {
            let arrTmp = [];
            for (let i = 0; i < arr.length; ++i) {
                if (arr[i].Id !== id)
                    arrTmp.push(arr[i]);
            }

            arr = arrTmp;
        }
    }


    static create(controllerName, obj) {
        switch (controllerName) {
            case "Facility": return this.Facility.push(obj);
            case "Patient": return this.Patient.push(obj);
            case "FacilityStatus": return this.FacilityStatus.push(obj);
        }
    }



    static delete(controllerName, id) {
        switch (controllerName) {
            case "Facility": return this.removeData(id, this.Facility);
            case "Patient": return this.removeData(id, this.Patient);
            case "FacilityStatus": return this.removeData(id, this.FacilityStatus);
        }
    }


    static update(controllerName, obj) {
        switch (controllerName) {
            case "Facility": return this.updateData(obj.Id, this.Facility, obj);
            case "Patient": return this.updateData(obj.Id, this.Patient, obj);
            case "FacilityStatus": return this.updateData(obj.Id, this.FacilityStatus, obj);
        }
    }


    static getCountOfPages(controllerName, perPage) {
        switch (controllerName) {
            case "Facility": return Math.ceil(this.Facility.length / perPage);
            case "Patient": return Math.ceil(this.Patient.length / perPage);;
            case "FacilityStatus": return Math.ceil(this.FacilityStatus.length / perPage);;
        }
    }


   static getItem(controllerName, id) {
        switch (controllerName) {
            case "Facility": return this.Facility.find(elem => elem.Id == id);
            case "Patient": return this.Patient.find(elem => elem.Id == id);
            case "FacilityStatus": return this.FacilityStatus.find(elem => elem.Id == id);
        }
    }


    static getItemPage(controllerName, perPage, currentPage) {
        switch (controllerName) {
            case "Facility": return this.getRange(perPage, currentPage, this.Facility);
            case "Patient": return this.getRange(perPage, currentPage, this.Patient);
            case "FacilityStatus": return this.getRange(perPage, currentPage, this.FacilityStatus);
        }
    }


    static getAll(controllerName) {
        switch (controllerName) {
            case "Facility": return this.Facility;
            case "Patient": return this.Patient;
            case "FacilityStatus": return this.FacilityStatus;
        }
    }

}