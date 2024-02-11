'use client';

import React from 'react';
import {usePostRequest} from "@/hooks/usePostRequest";
import AuctionsApiManager, {ICategory} from "@/features/auctions/api/AuctionsApiManager";
import {useForm} from "react-hook-form";
import {useGetRequest} from "@/hooks/useGetRequest";
import {Card} from "@mui/joy";
import Box from "@mui/joy/Box";
import Typography from "@mui/joy/Typography";

const CreateAuction = () => {
    console.log('CreateAuction')
    const PostAuction = usePostRequest({
        mutationKey: ['postAuction'],
        mutationFn: AuctionsApiManager.postAuction
    })

    const Categories = useGetRequest<ICategory[]>({
        queryKey: ['getCategories'],
        queryFn: AuctionsApiManager.getCategories,
        select: data => data.data as ICategory[]
    })

    const {} = useForm({
        defaultValues: {
            "title": "",
            "description": "",
            "categoryId": 0,
            "statusId": 0,
            "conditionId": 0
        }
    })

    return (
        <Box>
            <Card sx={{ maxWidth: '800px'}}>
                <Typography>Create Auction</Typography>
            </Card>
        </Box>
    );
};

export default CreateAuction;
