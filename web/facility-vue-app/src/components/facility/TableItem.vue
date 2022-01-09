<template>
    <tr>
        <td> {{ item.Id }}                 </td>
        <td> {{ item.Name }}               </td>
        <td> {{ item.Address}}             </td>
        <td> {{ item.PhoneNumber}}         </td>
        <td> {{ item.Email}}               </td>
        <td> {{ item.FacilityStatus.Name}} </td>
        <td> <button v-on:click='removeCallback(item.Id)' class='btn btn-danger'> Delete </button></td>
        <td> <button v-on:click='updateCallback(item)' class='btn btn-warning'>    Update </button></td>
    </tr>
</template>


<script lang="ts">
    import { defineComponent } from "vue";

    export default defineComponent({
        name : "facility-item",
        props: ["item", "updateCallback", "removeCallback"],
    });

</script>
