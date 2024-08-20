import ItemImage from "@/components/core/ItemImage";
import Heading from "@/components/core/Heading";
import InventoryItemDeleteButton from "@/components/inventory/InventoryItemDeleteButton";
import InventoryItemDetailedSpecs from "@/components/inventory/InventoryItemDetailedSpecs";
import InventoryItemEditButton from "@/components/inventory/InventoryItemEditButton";
import AdvertisementCreateButton from "@/components/advertisement/AdvertisementCreateButton";
import { detailsOffer } from "@/actions/offer";

export default async function Details({params} : {params: {id : string}}) {
  const data = await detailsOffer(params.id)
  console.log(data.itemsToExchange)
  
  return (
    <div>
        Offer details page.
    </div>
  )
}