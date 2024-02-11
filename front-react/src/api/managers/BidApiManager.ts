import {axiosServiceConfig} from "@/api/axiosConfig";

export default class BidApiManager {
    static async postBid(
        {
            auctionId,
            userEmail,
            bidAmount,
        }: {
            auctionId: number,
            userEmail: string,
            bidAmount: number,
        }) {
        return await axiosServiceConfig.post(
            '/api/Bid/createBid',
            {
                bidAmount: bidAmount
            },
            {
                params: {
                    userEmail: userEmail,
                    auctionId: auctionId,
                }
            }
        )
    }


}