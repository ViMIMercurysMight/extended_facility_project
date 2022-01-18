<template>
    <tr>
        <td> {{ item.id ? item.id : 0 }}                 </td>
        <td> {{ item.firstName ? item.firstName : "" }}               </td>
        <td> {{ item.lastName ? item.lastName : ""}}             </td>
        <td> {{ item.dateOfBirth ? item.dateOfBirth.toLocaleString() : ""}}         </td>
        <td> {{ item.facility ? item.facility.name : ""}} </td>
        <td> <a v-on:click='removeCallback(item.id ? item.id : -1)' class='remove-btn'></a></td>
        <td> <a v-on:click='updateCallback(item ? item : {})' class='update-btn'></a></td>
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
        color : yellow;
    }

    .remove-btn:before {
        content: "\f00d";
        font-family: FontAwesome;
        color : red;
        
    }

    @media screen and (max-width:760px) {
        button {
            width: 0.7vw;
            font-size : 0px;
        }
    }

    @media screen and (min-width:800px) and (max-width:900px) {
        button {
            font-size:3vw;
        }

        tr{
            font-size:3vw;
        }
    }


    @media screen and (min-width:900px) and (max-width : 1000px) {
        button {
            font-size: 3.5vw;
        }

        tr {
            font-size: 3vw;
        }
    }


    @media screen and (min-width:1000px)  {
        button {
            font-size: 1.5vw;
        }

        tr {
            font-size: 1.5vw;
        }
    }


  
</style>
