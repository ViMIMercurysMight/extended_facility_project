
<template>

</template>


<script lang="ts">
    import { defineComponent } from "vue";


    import PatientForm from "./PatientForm.vue";
    import PatientItem from "./PatientItem.vue";
    import PatientTable from "./PatientTable.vue";



    export default defineComponent({
        name: "patient-root-component",
        components: {
            "patient-form": PatientForm,
            "patient-item": PatientItem,
            "patient-table": PatientTable,
        }

    });

</script>

