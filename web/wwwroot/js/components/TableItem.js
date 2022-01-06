


Vue.component("facility-item", {

    props: ["item", "updateCallback", "removeCallback"],
    template: ` 
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
 
            `,


});
