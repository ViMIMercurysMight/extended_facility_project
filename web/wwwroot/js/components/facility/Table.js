export default {

        props: ["items", "createCallback", 'updateCallback', 'removeCallback', 'pageCount', 'changePageCallback'],

        data: {
            showUpdate: false,
            updatedItemId: -1,

        },

        template: `<div>
          
            <table class='table thead-dark'>
                 <thead>
                        <tr>
                            <td>Id              </td>
                            <td>Name            </td>
                            <td>Address         </td> 
                            <td>Phone Number    </td> 
                            <td>Email           </td> 
                            <td>FacilityStatus  </td>
                            <td>remove          </td>
                            <td>update          </td> 
                        </tr>
                 </thead>
             
                 <tbody>
                    <facility-item
                                v-for='item in items'
                                :update-callback='updateCallback'
                                :remove-callback='removeCallback'
                                :item='item' ></facility-item>
                  </tbody>
            </table>
            
            <pagination :page-count='pageCount' :change-page-callback='changePageCallback'></pagination>
         
            <button v-on:click='createCallback' class='btn btn-info'> Create </button>
        
             </div>`

    };
