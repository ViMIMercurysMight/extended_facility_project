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


    static getRange(start : number, end : number, arr : any) {
       // return this.arr.slice(
      //      this.arr.indexOf(this.arr[perPage * currentPage]),
        //    this.arr.indexOf(this.arr[perPage * currentPage + perPage]));
    }


    static updateData(id : number, arr : any, obj : any) {
        const item = arr.find((elem :any) => elem.Id == id);
        if (item) 
            arr[arr.findIndex((elem:any) => elem.Id == id)] = obj;
        
    }


    static removeData(id : number, arr : any) {
        const item = arr.find((elem:any) => elem.Id == id);
        if (item) {
            const arrTmp = [];
            for (let i = 0; i < arr.length; ++i) {
                if (arr[i].Id !== id)
                    arrTmp.push(arr[i]);
            }

            arr = arrTmp;
        }
    }


    static create(controllerName : string, obj : any) {
        switch (controllerName) {
            case "Facility": return this.Facility.push(obj);
            case "Patient": return this.Patient.push(obj);
            case "FacilityStatus": return this.FacilityStatus.push(obj);
        }
    }



    static delete(controllerName : string, id : number) {
        switch (controllerName) {
            case "Facility": return this.removeData(id, this.Facility);
            case "Patient": return this.removeData(id, this.Patient);
            case "FacilityStatus": return this.removeData(id, this.FacilityStatus);
        }
    }


    static update(controllerName : string, obj : any) {
        switch (controllerName) {
            case "Facility": return this.updateData(obj.Id, this.Facility, obj);
            case "Patient": return this.updateData(obj.Id, this.Patient, obj);
            case "FacilityStatus": return this.updateData(obj.Id, this.FacilityStatus, obj);
        }
    }


    static getCountOfPages(controllerName : string, perPage : number) {
        switch (controllerName) {
            case "Facility": return Math.ceil(this.Facility.length / perPage);
            case "Patient": return Math.ceil(this.Patient.length / perPage);
            case "FacilityStatus": return Math.ceil(this.FacilityStatus.length / perPage);
        }
    }


   static getItem(controllerName : string, id : number) {
        switch (controllerName) {
            case "Facility": return this.Facility.find( (elem : any) => elem.Id == id);
            case "Patient": return this.Patient.find( (elem : any) => elem.Id == id);
            case "FacilityStatus": return this.FacilityStatus.find(elem => elem.Id == id);
        }
    }


    static getItemPage(controllerName : string, perPage : number, currentPage : number) {
        switch (controllerName) {
            case "Facility": return this.getRange(perPage, currentPage, this.Facility);
            case "Patient": return this.getRange(perPage, currentPage, this.Patient);
            case "FacilityStatus": return this.getRange(perPage, currentPage, this.FacilityStatus);
        }
    }


    static getAll(controllerName : string) {
        switch (controllerName) {
            case "Facility": return this.Facility;
            case "Patient": return this.Patient;
            case "FacilityStatus": return this.FacilityStatus;
        }
    }

}