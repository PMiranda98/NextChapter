import { getDetailedViewData } from "@/actions/inventory";
import ItemImage from "@/components/advertisement/ItemImage";
import InventoryItemDetailedSpecs from "@/components/inventory/InventoryItemDetailedSpecs";

export default async function Details({params} : {params: {id : string}}) {
  const data = await getDetailedViewData(params.id)

  return (
    <div className={`grid grid-cols-2 gap-6 mt-3`}>
        <div className='w-full bg-gray-200 aspect-h-10 aspect-w-16 rounded-lg overflow-hidden'>
          <ItemImage image={data.photo}/>
        </div>
        
        <div className='rounded-lg'>
          <InventoryItemDetailedSpecs inventoryItem={data}/>
        </div>
      </div>
  )
}