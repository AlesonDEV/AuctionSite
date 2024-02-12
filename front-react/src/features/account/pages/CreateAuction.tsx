'use client';

import React from 'react';
import {usePostRequest} from "@/hooks/usePostRequest";
import AuctionsApiManager, { type ICategory, type IAuctionPost} from "@/features/auctions/api/AuctionsApiManager";
import {Controller, useForm} from "react-hook-form";
import {useGetRequest} from "@/hooks/useGetRequest";
import {Card, Select, Textarea, Option as SelectOption, Checkbox} from "@mui/joy";
import Box from "@mui/joy/Box";
import Typography from "@mui/joy/Typography";
import FormControl from "@mui/joy/FormControl";
import FormLabel from "@mui/joy/FormLabel";
import Input from "@mui/joy/Input";
import Button from "@mui/joy/Button";
import Cookies from "js-cookie";
import {COOKIES} from "@/api/apiConsts";

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

    const {
        handleSubmit,
        register,
        formState: {errors, },
    } = useForm({
        defaultValues: {
            "title": "",
            "description": "",
            "categoryId": 0,
            "statusId": 0,
            "conditionId": 0
        } as IAuctionPost
    })

    const onSubmit = (data: IAuctionPost) => {
        console.log(data)
        const email = Cookies.get(COOKIES.EMAIL)
        if ( !!email ) {
            PostAuction.mutate({
                data: {
                    ...data,
                    categoryId: Number(data.categoryId),
                    conditionId: Number(data.conditionId)
                },
                email: email.replace('%40', '@')
            })
        }
    }

    return (
        <Box>
            <Card sx={{maxWidth: '600px'}}>
                <Typography level={'h3'}>Create Auction</Typography>
                <form
                    onSubmit={handleSubmit(onSubmit)}
                    style={{
                        display: 'flex',
                        flexDirection: 'column',
                        gap: 2,

                    }}
                >

                    <FormControl>
                        <FormLabel>{errors?.title?.message}</FormLabel>
                        <Input
                            placeholder={'Auction title'}
                            {...register('title', {required: true})}
                        />
                    </FormControl>

                    <FormControl>
                        <FormLabel>{errors?.description?.message}</FormLabel>
                        <Textarea
                            minRows={2}
                            placeholder={'Auction description'}
                            {...register('description',
                                {
                                    required: true
                                }
                            )}
                        />
                    </FormControl>

                    <FormControl>
                        <FormLabel>{errors?.categoryId?.message}</FormLabel>
                        <Select
                            placeholder={'Select category'}
                            {...register('categoryId', {required: true})}
                            onChange={(event, value) => {
                                register('categoryId').onChange(event as {target: any, type?: any})
                            }}
                        >
                            {
                                Categories.data?.map(category => (
                                    <SelectOption
                                        value={category.id}
                                        key={category.name}
                                    >{category.name}</SelectOption>
                                ))
                            }
                        </Select>
                    </FormControl>

                    <FormControl>
                        <FormLabel>{errors?.conditionId?.message}</FormLabel>
                        <Select
                            placeholder={'Select state'}

                            {...register('conditionId', {required: true})}
                            onChange={(event, value) => {
                                register('conditionId').onChange(event as {target: any, type?: any})
                            }}
                        >
                            <SelectOption
                                value={0}
                            >Brand new</SelectOption>
                            <SelectOption
                                value={1}
                            >Used</SelectOption>
                        </Select>
                    </FormControl>
                    <Button
                        size={'sm'}
                        type={'submit'}
                        color={'success'}
                        sx={{
                            width: '6rem',
                            marginY: '1rem',
                        }}
                    >Create</Button>
                </form>
            </Card>
        </Box>
    );
};

export default CreateAuction;
