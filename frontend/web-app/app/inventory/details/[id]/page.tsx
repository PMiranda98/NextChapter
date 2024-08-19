import { getDetailedViewData } from "@/actions/inventory";
import ItemImage from "@/components/core/ItemImage";
import Heading from "@/components/core/Heading";
import InventoryItemDeleteButton from "@/components/inventory/InventoryItemDeleteButton";
import InventoryItemDetailedSpecs from "@/components/inventory/InventoryItemDetailedSpecs";
import InventoryItemEditButton from "@/components/inventory/InventoryItemEditButton";
import AdvertisementCreateButton from "@/components/advertisement/AdvertisementCreateButton";

export default async function Details({params} : {params: {id : string}}) {
  const data = await getDetailedViewData(params.id)

  return (
    <>
      <div className='flex justify-between'>
        <div className='flex gap-3 items-center'>
          <Heading title={`${data.name}`}/>
          <InventoryItemEditButton id={data.id}/>
          <InventoryItemDeleteButton id={data.id} />
          <AdvertisementCreateButton item={data}/>
        </div>
      </div>
      <div className={`grid grid-cols-[30%_70%] gap-6 mt-3`}>
        <div className='w-full bg-gray-200 aspect-h-10 aspect-w-16 rounded-lg overflow-hidden'>
          <ItemImage image={data.photo}/>
        </div>
        
        <div className='rounded-lg'>
          <InventoryItemDetailedSpecs inventoryItem={data}/>
        </div>
      </div>
    </>
  )
}