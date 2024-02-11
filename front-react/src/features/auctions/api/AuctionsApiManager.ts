import {axiosServiceConfig} from '@/api/axiosConfig';
// import type { IAuction, IAuctionResponse, IAuctionPost } from '@/features/auctions/models'
import axios from "axios";

export interface IAuction {
    auctionId: number
    title: string
    currentBid: number
    currentNumberOfBid: number
    startTime: string
    endTime: string
}

export interface IAuctionResponse {
    id: number
    title: string
    description: string
    date: string
    currentBid: number
    countOfParticipants: number
}

export interface IAuctionPost {
    title: string
    description: string
    categoryId: number
    statusId: number
    conditionId: number
}

export interface ICategory {
    id: number
    name: string
}

export default class AuctionsApiManager {
    static async getAuctions({count}: {count?: number}){
        return await axiosServiceConfig.get<IAuction[]>('/api/Auction/previewInfo/'+ String(count ? count : 10))
    }

    static async getAuctionInfo({id}: {id: number}) {
        return await axiosServiceConfig.get<IAuctionResponse>('/api/Auction/detailInfo/'+id)
    }

    static async postAuction({data, email}: {data: IAuctionPost, email: string}) {
        return await axiosServiceConfig.post(
            '/api/Auction/createAuction',
            data,
            {
                params: {
                    userEmail: email,
                }
            }
        )
    }

    static async deleteAuction({id}: {id: number}) {
        return await axiosServiceConfig.delete(
            '/api/Auction/createAuction/' + id,
        )
    }

    static async getUserAuctions({ email }: {email: string}) {
        return await axiosServiceConfig.get(
            '/api/Auction/previewInfoByUser/'+email
        )
    }

    static async getCategories() {
        return await axiosServiceConfig.get(
            '/api/Category'
        )
    }
}

// export const randomImageUrl = 'https://random.imagecdn.app/500/150'
export const randomImageUrl = 'https://picsum.photos/200';