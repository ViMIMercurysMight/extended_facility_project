<template>
    <tr>
        <td> {{ item.id ? item.id : 0 }}                 </td>
        <td> {{ item.firstName ? item.firstName : "" }}               </td>
        <td> {{ item.lastName ? item.lastName : ""}}             </td>
        <td> {{ item.dateOfBirth ? item.dateOfBirth.toLocaleString() : ""}}         </td>
        <td> {{ item.facility ? item.facility.name : ""}} </td>
        <td> <a title="remove patient" v-on:click='removeCallback(item.id ? item.id : -1)' class='remove-btn'></a></td>
        <td> <a title="edit patient" v-on:click='updateCallback(item ? item : {})' class='update-btn'></a></td>
    </tr>
</template>


<script lang="ts">
    import { defineComponent } from "vue";

    export default defineComponent({
        name: "patient-item",
        props: ["item", "updateCallback", "removeCallback"],
    });

</script>





<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">


    a {
        text-decoration : none;
    }


    .update-btn:before {
        content: "\f040";
        font-family: FontAwesome;
        color: #ffc107;
    }

    .remove-btn:before {
        content: "\f00d";
        font-family: FontAwesome;
        color: #dc3545;
    }


    @media screen and ( max-width: 1400px) and (min-width : 900px) {
        tr {
            font-size: 1vw;
        }
    }

    @media screen and (max-width:900px) and (min-width:600px) {
        tr {
            font-size: 1.5vw;
        }
    }

    @media screen and (max-width:600px) and (min-width:400px) {
        tr {
            font-size: 1.5vw;
        }
    }
  
</style>
