import Vue from "vue";

import PatientForm from "./PatientForm";
import PatientItem from "./PatientItem";
import PatientTable from "./PatientTable";


Vue.component("PatientRoot", {

    components: {
        PatientForm,
        PatientItem,
        PatientTable,
    }

});