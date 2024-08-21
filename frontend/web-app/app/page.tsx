import { getCurrentUser } from "@/actions/auth";
import AdvertisementListing from "../components/advertisement/AdvertisementListing";

export default async function Home() {
  const username = await getCurrentUser().then((user) => user?.username)
  console.log(username)

  return (
    <div>
      <AdvertisementListing username={username}/>
    </div>
  );
}
