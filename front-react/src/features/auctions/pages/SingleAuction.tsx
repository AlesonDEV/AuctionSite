'use client';
import React, {lazy, Suspense, useState} from 'react';
import {useGetRequest} from "@/hooks/useGetRequest";
import AuctionsApiManager, {randomImageUrl} from "@/features/auctions/api/AuctionsApiManager";
import Box from "@mui/joy/Box";
import Stack from "@mui/joy/Stack";
import Typography from "@mui/joy/Typography";
import type {IAuctionResponse} from "@/features/auctions/api/AuctionsApiManager";
import Loader from '@/components/Loader'
import Button from "@mui/joy/Button";
import {usePostRequest} from "@/hooks/usePostRequest";
// import MakeABid from '../components/MakeABid'

const MakeABid = lazy(() => import('../components/MakeABid'))

const SingleAuction = (props: NextProps) => {
    const AuctionID: number = props.params.id as number;

    const AuctionData = useGetRequest<IAuctionResponse>({
        queryKey: ['getAuction', AuctionID],
        queryFn: AuctionsApiManager.getAuctionInfo,
        params: {
            id: AuctionID
        },
        select: data => data.data as IAuctionResponse
    })

    const [makeBidOpenModal, setMakeBidOpenModal] = useState(false)

    const makeBid = () => {
        setMakeBidOpenModal(true)
    }

    const closeBidModal = () => {
        setMakeBidOpenModal(false)
    }

    return (
        <Box
            sx={{
                height: '100dvh',
                width: '100vw',
                flex: '1',
                padding: 2
            }}
        >
            {
                makeBidOpenModal && (
                    <Suspense fallback={
                        <Loader isLoading>
                            <></>
                        </Loader>
                    }>
                        <MakeABid
                            isOpened={makeBidOpenModal}
                            close={closeBidModal}
                            AuctionID={AuctionID}
                        />
                    </Suspense>
                )
            }
            <Loader isLoading={AuctionData.isLoading}>
                <Stack
                    direction={'row'}
                    justifyContent={'flex-start'}
                    spacing={2}
                >
                    <img
                        src={randomImageUrl}
                        alt=""
                        style={{
                            height: '20rem',
                            width: '20rem',
                            maxHeight: '20rem',
                            maxWidth: '20rem',
                            objectFit: 'cover',
                            borderRadius: '8px',
                        }}
                    />
                    <Box sx={{
                        display: 'flex',
                        flexDirection: 'column',
                        justifyContent: 'flex-start',
                        gap: 1
                    }}>
                        <Typography level={'h2'}>{AuctionData.data?.title}</Typography>
                        <Typography level={'h3'}>The highest bid: {AuctionData.data?.currentBid}</Typography>
                        <Typography level={'h3'}>Number of
                            Participation's: {AuctionData.data?.countOfParticipants}</Typography>
                        <Typography
                            sx={{
                                wordBreak: 'break-word',
                                textWrap: 'wrap',
                                maxWidth: '30rem',
                            }}
                            level={'body-lg'}
                        >{AuctionData.data?.description}</Typography>
                        <Box
                            sx={{
                                display: 'flex',
                                justifyContent: 'space-between',

                            }}
                        >
                            <Typography level={'h3'}>Participate in the auction: </Typography>
                            <Button
                                color={'success'}
                                onClick={makeBid}
                            >Make a bid</Button>
                        </Box>
                    </Box>
                </Stack>
            </Loader>
        </Box>
    );
};

export default SingleAuction;
